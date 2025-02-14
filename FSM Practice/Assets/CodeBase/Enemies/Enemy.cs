using System.Collections.Generic;
using CodeBase.Enemies.Factory;
using CodeBase.Infrastructure;
using UnityEngine;

namespace CodeBase.Enemies
{
	[RequireComponent(typeof(EnemyStateMachineFactory))]
	[RequireComponent(typeof(SphereCollider))]
	public class Enemy : MonoBehaviour
	{
		[SerializeField] private float _runAwayTime = 5f;
		
		private StateMachine _stateMachine;
		private SphereCollider _sphereCollider;
		private float _time = -10f;

		public float Speed { get; set; } = 1;
		public bool IsInRunAway => _time + _runAwayTime > Time.time;

		public bool IsPlayerDetected => DetectPlayer();

		private bool DetectPlayer()
		{
			return Physics.OverlapSphere(transform.position, _sphereCollider.radius, LayerMask.GetMask("Player")).Length > 0;
		}

		public void Initialize(WayPoints wayPoints, Player player)
		{
			_stateMachine = GetComponent<EnemyStateMachineFactory>().Create(this, wayPoints, player);
		}

		private void Awake()
		{
			_sphereCollider = GetComponent<SphereCollider>();
		}

		private void Update()
		{
			_stateMachine?.Update();
		}

		public void MoveTo(Vector3 dir)
		{
			transform.position = Vector3.MoveTowards(transform.position, dir, Speed * Time.deltaTime);
			var direction = (dir - transform.position).normalized;
			transform.forward = direction;
		}

		public void RunAway()
		{
			_time = Time.time;
			
		}
	}
}