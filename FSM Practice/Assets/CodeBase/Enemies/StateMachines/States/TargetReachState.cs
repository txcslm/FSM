using CodeBase.Infrastructure;

namespace CodeBase.Enemies.StateMachines.States
{
	public class TargetReachState : State
	{
		private readonly WayPoints _wayPoints;

		public TargetReachState(IStateChanger stateChanger, WayPoints wayPoints) : base(stateChanger)
		{
			_wayPoints = wayPoints;
		}

		public override void Enter()
		{
			_wayPoints.MoveNext();
		}
	}
}