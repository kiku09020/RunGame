using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.State {
	public class MoveState : PlayerStateBase {

		[SerializeField] PlayerMover mover;
		[SerializeField] PlayerCore player;

		//--------------------------------------------------

		public override void OnEnter()
		{
			animator.SetBool("Walking", true);
		}

		public override void OnUpdate()
		{
			// ‘Ò‹@ó‘Ô‚É‘JˆÚ
			if (!mover.IsMoving) {
				state.StateTransition<IdleState>();
			}

			// ƒ_ƒ[ƒWó‘Ô‚É‘JˆÚ
			if (player.IsDamaged) {
				state.StateTransition<DeadState>();
			}

			// ƒS[ƒ‹ó‘Ô‚É‘JˆÚ
			if(player.IsGoaled) {
				state.StateTransition<GoalState>();
			}
		}

		public override void OnExit()
		{
			animator.SetBool("Walking", false);
		}
	}
}