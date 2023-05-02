using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.State {
	public class IdleState : PlayerStateBase {

		[SerializeField] PlayerMover mover;
		[SerializeField] PlayerCore player;

		//--------------------------------------------------

		public override void OnEnter()
		{
			animator.SetBool("Standing", true);
		}

		public override void OnUpdate()
		{
			// ˆÚ“®ó‘Ô‚É‘JˆÚ
			if (mover.IsMoving) {
				state.StateTransition<MoveState>();
			}

			// ƒ_ƒ[ƒWó‘Ô‚É‘JˆÚ
			if (player.IsDamaged) {
				state.StateTransition<DeadState>();
			}

			// ƒS[ƒ‹ó‘Ô
			if(player.IsGoaled) {
				state.StateTransition<GoalState>();
			}
		}

		public override void OnExit()
		{
			animator.SetBool("Standing", false);

		}
	}
}