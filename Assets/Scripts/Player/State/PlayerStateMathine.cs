using GameController.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.State {
	public class PlayerStateMathine : StateMathine_Base<PlayerStateBase> {
		[Header("Common Components")]
		[SerializeField] Animator animator;

		protected override void AllStatesInit()
		{
			foreach (var state in states) {
				state.StateSetup(animator, this);
			}

			StateInit();
		}
	}
}