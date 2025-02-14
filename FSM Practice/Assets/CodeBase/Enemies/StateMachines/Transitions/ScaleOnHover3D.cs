using UnityEngine;

public class ScaleOnHover3D : MonoBehaviour
{
  [SerializeField] private Vector3 _hoverScale = new Vector3(1.2f, 1.2f, 1.2f);
  [SerializeField] private float _scaleSpeed = 5f;

  private Vector3 _originalScale;
  private bool _isHovered = false;

  private void Awake()
  {
    _originalScale = transform.localScale;
  }

  private void Update()
  {
    CheckForHover();
    UpdateScale();
  }

  private void CheckForHover()
  {
    if (Camera.main == null)
      return;
    
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    if (Physics.Raycast(ray, out RaycastHit hit))
      _isHovered = hit.collider.gameObject == gameObject;
    else
      _isHovered = false;
  }

  private void UpdateScale()
  {
    transform.localScale = Vector3.Lerp(transform.localScale, _isHovered ? _hoverScale : _originalScale, Time.deltaTime * _scaleSpeed);
  }
}