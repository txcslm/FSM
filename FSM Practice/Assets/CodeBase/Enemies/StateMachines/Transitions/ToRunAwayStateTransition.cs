using CodeBase.Enemies.StateMachines.States;
using CodeBase.Infrastructure;

namespace CodeBase.Enemies.StateMachines.Transitions
{
	public class ToRunAwayStateTransition : Transition
	{
		private readonly Enemy _enemy;

		public ToRunAwayStateTransition(RunAwayState nextState, Enemy enemy) : base(nextState)
		{
			_enemy = enemy;
		}

		protected override bool CanTransit() =>
			_enemy.IsPlayerDetected;
	}
}