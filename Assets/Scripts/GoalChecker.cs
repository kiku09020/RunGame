using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalChecker : MonoBehaviour
{
	/// <summary>
	/// ゴールしたかどうか
	/// </summary>
    public bool IsGoaled { get; private set; }

	//--------------------------------------------------

	// 破棄時にリセット
	private void OnDestroy()
	{
		IsGoaled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Goal") {
			IsGoaled = true;
		}
	}
}
