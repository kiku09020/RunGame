using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.State {
    public class DeadState : PlayerStateBase {

		//--------------------------------------------------

		private void Start()
		{
			
		}

		public override void OnEnter()
		{
			animator.SetBool("Damaged", true);
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{
			animator.SetBool("Damaged", false);
		}

		// •œŠˆˆ—
		void Revival()
		{

		}
	}
}