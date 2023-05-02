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
			// �ړ���ԂɑJ��
			if (mover.IsMoving) {
				state.StateTransition<MoveState>();
			}

			// �_���[�W��ԂɑJ��
			if (player.IsDamaged) {
				state.StateTransition<DeadState>();
			}

			// �S�[�����
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