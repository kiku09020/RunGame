using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalChecker : MonoBehaviour
{
	/// <summary>
	/// �S�[���������ǂ���
	/// </summary>
    public bool IsGoaled { get; private set; }

	//--------------------------------------------------

	// �j�����Ƀ��Z�b�g
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
