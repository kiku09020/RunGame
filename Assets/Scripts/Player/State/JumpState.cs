using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerStateBase
{

	//--------------------------------------------------

	public override void OnEnter()
	{
		animator.SetTrigger("Jumping");
	}

	public override void OnUpdate()
	{

	}

	public override void OnExit()
	{

	}
}
