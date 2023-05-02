using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.State {
    public class DeadState : PlayerStateBase {

		[Header("Components")]
		[SerializeField] PlayerLifeController lifeController;

		//--------------------------------------------------

		public override void OnEnter()
		{
			animator.SetBool("Damaged", true);
			lifeController.Dead();			
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{
			animator.SetBool("Damaged", false);
		}
	}
}