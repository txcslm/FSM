using CodeBase.Enemies.StateMachines.States;
using CodeBase.Infrastructure;

namespace CodeBase.Enemies.StateMachines.Transitions
{
	public class ToStopRunAwayTransition : Transition
	{
		private readonly Enemy _enemy;

		public ToStopRunAwayTransition(MoveState nextState, Enemy enemy) : base(nextState)
		{
			_enemy = enemy;
		}

		protected override bool CanTransit() =>
			_enemy.IsInRunAway == false;
	}
}