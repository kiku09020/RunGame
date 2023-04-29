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
			if (mover.IsMoving) {
				state.StateTransition<MoveState>();
			}

			if (player.IsDamaged) {
				state.StateTransition<DeadState>();
			}
		}

		public override void OnExit()
		{
			animator.SetBool("Standing", false);

		}
	}
}