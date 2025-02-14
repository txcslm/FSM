using CodeBase.Enemies.StateMachines.States;
using CodeBase.Enemies.StateMachines.Transitions;
using CodeBase.Infrastructure;
using UnityEngine;

namespace CodeBase.Enemies.Factory
{
	public class EnemyStateMachineFactory : MonoBehaviour
	{
		public StateMachine Create(Enemy enemy, WayPoints wayPoints, Player player)
		{
			var stateMachine = new StateMachine();
			
			var moveState = new MoveState(stateMachine, enemy, wayPoints);
			var targetReachState = new TargetReachState(stateMachine, wayPoints);
			var runAwayState = new RunAwayState(stateMachine, enemy, player);
			
			
			var toMoveStateTransition = new ToMoveStateTransition(moveState, enemy, wayPoints);
			var toTargetReachTransition = new ToTargetReachTransition(targetReachState, enemy, wayPoints);
			var toRunAwayTransition = new ToRunAwayStateTransition(runAwayState, enemy);
			var toStopTransition = new ToStopRunAwayTransition(moveState, enemy);
			
			runAwayState.AddTransition(toStopTransition);
			targetReachState.AddTransition(toMoveStateTransition);
			moveState.AddTransition(toRunAwayTransition);
			moveState.AddTransition(toTargetReachTransition);
			
			stateMachine.ChangeState(moveState);
			return stateMachine;
		}
	}
}
