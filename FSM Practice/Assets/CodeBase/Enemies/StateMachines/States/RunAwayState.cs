using CodeBase.Infrastructure;

namespace CodeBase.Enemies.StateMachines.States
{
	public class RunAwayState : State
	{
		private readonly Enemy _enemy;
		private readonly Player _player;

		public RunAwayState(IStateChanger stateChanger, Enemy enemy, Player player) : base(stateChanger)
		{
			_enemy = enemy;
			_player = player;
		}
		
		protected override void OnUpdate()
		{
			var direction = _enemy.transform.position - _player.transform.position;
			_enemy.MoveTo(direction + _enemy.transform.position);
		}

		public override void Enter()
		{
			_enemy.Speed = 2;
			_enemy.RunAway();
		}
	}

}