using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] float speed = 50;
    [SerializeField] float maxVel = 200;
    [SerializeField] float moveThreshold = 0.5f;

    Vector3 moveVec;

    [Header("Components")]
    [SerializeField] Transform targetTransform;
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerStateMathine state;

    public bool IsMoving { get; private set; }

    //--------------------------------------------------

    // ˆÚ“®ŠÖŒW‚Ì“ü—ÍŽæ“¾
    public void OnMove(InputAction.CallbackContext context)
    {
        var axis = context.ReadValue<Vector3>();

        moveVec = new Vector3(axis.x, 0, axis.z);
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude < maxVel) {
            var forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            var moveForword = forward * moveVec.z + Camera.main.transform.right * moveVec.x;

            rb.AddForce(moveForword * speed);
		}

		print(IsMoving);
        print(rb.velocity);

        print(rb.velocity.magnitude);
	}
}
