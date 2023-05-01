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
			// 待機状態に遷移
			if (!mover.IsMoving) {
				state.StateTransition<IdleState>();
			}

			// ダメージ状態に遷移
			if (player.IsDamaged) {
				state.StateTransition<DeadState>();
			}
		}

		public override void OnExit()
		{
			animator.SetBool("Walking", false);
		}
	}
}