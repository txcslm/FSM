using UnityEngine;

namespace CodeBase
{
	public class Player : MonoBehaviour
	{
		private const string HorizontalAxis = "Horizontal";
		private const string VerticalAxis = "Vertical";

		private void Update() =>
			Move();

		private void Move()
		{
			Vector3 direction = Input.GetAxis(HorizontalAxis) * Vector3.right + Input.GetAxis(VerticalAxis) * Vector3.forward;
			
			transform.position += direction * Time.deltaTime;
			transform.forward = direction;
		}
	}
}