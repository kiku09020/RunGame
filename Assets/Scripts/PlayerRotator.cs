using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotator : MonoBehaviour
{
	[SerializeField] Transform targetTransform;
	[SerializeField] float rotateSpeed = 10;

	Vector2 inputVector;
	Vector3 prevRot;

	//--------------------------------------------------

	void OnRotate(InputValue value)
	{
		inputVector = value.Get<Vector2>();
	}

	private void FixedUpdate()
	{
		prevRot.y += inputVector.x * rotateSpeed * Time.deltaTime;

		targetTransform.localEulerAngles = prevRot;
	}
}
