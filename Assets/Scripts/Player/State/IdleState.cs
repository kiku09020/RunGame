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
			// 移動状態に遷移
			if (mover.IsMoving) {
				state.StateTransition<MoveState>();
			}

			// ダメージ状態に遷移
			if (player.IsDamaged) {
				state.StateTransition<DeadState>();
			}

			// ゴール状態
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