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

	// 回転補正　参考： https://nekojara.city/unity-rotate-to-movement-direction
	private void FixedUpdate()
	{
		var delta = targetTransform.position - prevPos;
		prevPos = targetTransform.position;

		if (delta.magnitude != 0) {
			var ofstRot = Quaternion.Inverse(Quaternion.LookRotation(Vector3.forward));		// 補正

			var forword = targetTransform.TransformDirection(Vector3.forward);				// 前方ベクトル取得

			var prjFrom = Vector3.ProjectOnPlane(forword, Vector3.up);                      // 回転軸に垂直なベクトルを平面投影したベクトル
			var prjTo=Vector3.ProjectOnPlane(delta, Vector3.up);							

			var difAngle=Vector3.Angle(prjFrom, prjTo);										// 角度の差

			var rotAngle = Mathf.SmoothDampAngle(0, difAngle, ref currentVel, rotateDuration, Mathf.Infinity);		// 現在のフレームで回転する角度

			var lookFrom = Quaternion.LookRotation(prjFrom);								// 回転の開始・終了
			var lookTo=Quaternion.LookRotation(prjTo);

			var nextRot = Quaternion.RotateTowards(lookFrom, lookTo, rotAngle) * ofstRot;	// 回転

			targetTransform.rotation = nextRot;
		}
	}
}
