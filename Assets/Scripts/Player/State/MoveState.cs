using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : PlayerStateBase {

	[SerializeField] PlayerMover mover;
	//--------------------------------------------------

	public override void OnEnter()
	{
		animator.SetBool("Walking", true);
	}

	public override void OnUpdate()
	{
		if (!mover.IsMoving) {
			state.StateTransition<IdleState>();
		}
	}

	public override void OnExit()
	{
		animator.SetBool("Walking", false);
	}
}
