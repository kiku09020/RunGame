using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Player.State {
	public class JumpState : PlayerStateBase {
		[SerializeField] PlayerCore player;
		[SerializeField] PlayerJumper jumper;

		//--------------------------------------------------

		public override void OnEnter()
		{
			animator.SetBool("Jumping",true);
		}

		public override void OnUpdate()
		{
			// ���n������ҋ@��ԂɑJ��
			if (jumper.IsFalling && player.IsLanding) {
 				state.StateTransition<IdleState>();
			}

			// �_���[�W��ԂɑJ��
			if (player.IsDamaged) {
				state.StateTransition<DeadState>();
			}
		}

		public override void OnExit()
		{
			animator.SetBool("Jumping", false);
		}
	}
}