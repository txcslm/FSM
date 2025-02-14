using System.Collections.Generic;
using CodeBase.Infrastructure;
using UnityEngine;

namespace CodeBase.Enemies.StateMachines.States
{
	public class MoveState : State
	{
		private readonly Enemy _enemy;
		private readonly WayPoints _wayPoints;

		public MoveState(IStateChanger stateChanger, Enemy enemy, WayPoints wayPoints) : base(stateChanger)
		{
			_enemy = enemy;
			_wayPoints = wayPoints;
		}

		protected override void OnUpdate() =>
			_enemy.MoveTo(_wayPoints.NextPoint.position);

		public override void Enter()
		{
			_enemy.Speed = 1;
		}
	}
}