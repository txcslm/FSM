using CodeBase.Enemies.StateMachines.States;
using CodeBase.Infrastructure;
using UnityEngine;

namespace CodeBase.Enemies.StateMachines.Transitions
{
	public class ToTargetReachTransition : Transition
	{
		private readonly Enemy _enemy;
		private readonly WayPoints _wayPoints;

		public ToTargetReachTransition(TargetReachState nextState, Enemy enemy, WayPoints wayPoints) : base(nextState)
		{
			_enemy = enemy;
			_wayPoints = wayPoints;
		}

		protected override bool CanTransit() =>
			Vector3.Distance(_enemy.transform.position, _wayPoints.NextPoint.position) < 0.1f;
	}
}