using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotator : MonoBehaviour
{
	[SerializeField] Transform targetTransform;
	[SerializeField] float rotateDuration = 0.2f;
	[SerializeField] float rotateThreshold = 0.05f;

	Vector3 prevPos;
	float currentVel;

	//--------------------------------------------------

	private void Awake()
	{
		prevPos = targetTransform.position;
	}

	// ��]�␳�@�Q�l�F https://nekojara.city/unity-rotate-to-movement-direction
	private void FixedUpdate()
	{
		var delta = targetTransform.position - prevPos;
		prevPos = targetTransform.position;

		if (delta.magnitude != 0) {
			var ofstRot = Quaternion.Inverse(Quaternion.LookRotation(Vector3.forward));		// �␳

			var forword = targetTransform.TransformDirection(Vector3.forward);				// �O���x�N�g���擾

			var prjFrom = Vector3.ProjectOnPlane(forword, Vector3.up);                      // ��]���ɐ����ȃx�N�g���𕽖ʓ��e�����x�N�g��
			var prjTo=Vector3.ProjectOnPlane(delta, Vector3.up);							

			var difAngle=Vector3.Angle(prjFrom, prjTo);										// �p�x�̍�

			var rotAngle = Mathf.SmoothDampAngle(0, difAngle, ref currentVel, rotateDuration, Mathf.Infinity);		// ���݂̃t���[���ŉ�]����p�x

			var lookFrom = Quaternion.LookRotation(prjFrom);								// ��]�̊J�n�E�I��
			var lookTo=Quaternion.LookRotation(prjTo);

			var nextRot = Quaternion.RotateTowards(lookFrom, lookTo, rotAngle) * ofstRot;	// ��]

			targetTransform.rotation = nextRot;
		}
	}
}
