using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Enemies;
using UnityEngine;

namespace CodeBase
{
	public class Bootstrapper : MonoBehaviour
	{
		[SerializeField] private Transform _path;
		[SerializeField] private int _enemies = 4;
		[SerializeField] private Enemy _enemyPrefab;
		[SerializeField] private float _delay = 0.5f;
		[SerializeField] private Player _player;


		private WaitForSecondsRealtime _wait;
		
		private void Awake() =>
			_wait = new WaitForSecondsRealtime(_delay);

		private IEnumerator Start()
		{
			
			for (int i = 0; i < _enemies; i++)
			{
				yield return _wait;
				
				Enemy enemy = Instantiate(_enemyPrefab);
				enemy.Initialize(new WayPoints(_path.Cast<Transform>()), _player);
			}
		}
	}
}