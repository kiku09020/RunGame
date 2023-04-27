using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
	public class PlayerRotator : MonoBehaviour {
		[SerializeField] Transform targetTransform;
		[SerializeField] float rotateDuration = 0.2f;
		[SerializeField] float rotateThreshold = 0.01f;		// 臒l

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
			var pos = new Vector3(targetTransform.position.x, 0, targetTransform.position.z);

			var delta = pos - prevPos;
			prevPos = pos;

			if (delta.magnitude > rotateThreshold) {
				var ofstRot = Quaternion.Inverse(Quaternion.LookRotation(Vector3.forward, Vector3.up));     // �␳

				var forword = targetTransform.TransformDirection(Vector3.forward);							// �O���x�N�g���擾

				var prjFrom = Vector3.ProjectOnPlane(forword, Vector3.up);									// ��]���ɐ����ȃx�N�g���𕽖ʓ��e�����x�N�g��
				var prjTo = Vector3.ProjectOnPlane(delta, Vector3.up);

				var difAngle = Vector3.Angle(prjFrom, prjTo);												// �p�x�̍�

				var rotAngle = Mathf.SmoothDampAngle(0, difAngle, ref currentVel, rotateDuration, Mathf.Infinity);      // ���݂̃t���[���ŉ�]����p�x

				var lookFrom = Quaternion.LookRotation(prjFrom);											// ��]�̊J�n�E�I��
				var lookTo = Quaternion.LookRotation(prjTo);

				var nextRot = Quaternion.RotateTowards(lookFrom, lookTo, rotAngle) * ofstRot;				// ��]

				targetTransform.rotation = nextRot;
			}
		}
	}
}