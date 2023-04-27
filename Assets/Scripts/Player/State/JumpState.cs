using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.State {
	public class JumpState : PlayerStateBase {
		[SerializeField] PlayerLandingChecker landingChecker;
		[SerializeField] PlayerJumper jumper;

		//--------------------------------------------------

		public override void OnEnter()
		{
			animator.SetBool("Jumping",true);
		}

		public override void OnUpdate()
		{
			// ���n������ҋ@��ԂɑJ��
			if (jumper.IsFalling && landingChecker.IsLanding) {
				state.StateTransition<IdleState>();
			}
		}

		public override void OnExit()
		{
			animator.SetBool("Jumping", false);
		}
	}
}