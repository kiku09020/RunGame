using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerStateBase {

	[SerializeField] PlayerMover mover;

	//--------------------------------------------------

	public override void OnEnter()
	{
		animator.SetBool("Standing", true);
	}

	public override void OnUpdate()
	{
		if (mover.IsMoving){
			state.StateTransition<MoveState>();
		}
	}

	public override void OnExit()
	{
		animator.SetBool("Standing", false);

	}
}
