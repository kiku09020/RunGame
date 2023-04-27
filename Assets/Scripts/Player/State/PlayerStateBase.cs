using GameController.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.State {
	public abstract class PlayerStateBase : State_Base {
		protected Animator animator;
		protected PlayerStateMathine state;

		//--------------------------------------------------

		public void StateSetup(Animator animator, PlayerStateMathine state)
		{
			this.animator = animator;
			this.state = state;
		}
	}
}