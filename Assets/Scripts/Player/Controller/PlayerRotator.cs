using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
	public class PlayerRotator : MonoBehaviour {
		[SerializeField] Transform targetTransform;
		[SerializeField] float rotateDuration = 0.2f;
		[SerializeField] float rotateThreshold = 0.01f;		// 閾値

		Vector3 prevPos;
		float currentVel;

		//--------------------------------------------------

		private void Awake()
		{
			prevPos = targetTransform.position;
		}

		// 回転補正　参考： https://nekojara.city/unity-rotate-to-movement-direction
		private void FixedUpdate()
		{
			var pos = new Vector3(targetTransform.position.x, 0, targetTransform.position.z);

			var delta = pos - prevPos;
			prevPos = pos;

			if (delta.magnitude > rotateThreshold) {
				var ofstRot = Quaternion.Inverse(Quaternion.LookRotation(Vector3.forward, Vector3.up));     // 補正

				var forword = targetTransform.TransformDirection(Vector3.forward);							// 前方ベクトル取得

				var prjFrom = Vector3.ProjectOnPlane(forword, Vector3.up);									// 回転軸に垂直なベクトルを平面投影したベクトル
				var prjTo = Vector3.ProjectOnPlane(delta, Vector3.up);

				var difAngle = Vector3.Angle(prjFrom, prjTo);												// 角度の差

				var rotAngle = Mathf.SmoothDampAngle(0, difAngle, ref currentVel, rotateDuration, Mathf.Infinity);      // 現在のフレームで回転する角度

				var lookFrom = Quaternion.LookRotation(prjFrom);											// 回転の開始・終了
				var lookTo = Quaternion.LookRotation(prjTo);

				var nextRot = Quaternion.RotateTowards(lookFrom, lookTo, rotAngle) * ofstRot;				// 回転

				targetTransform.rotation = nextRot;
			}
		}
	}
}