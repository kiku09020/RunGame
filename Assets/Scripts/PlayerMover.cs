using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] float speed = 50;
    [SerializeField] float maxVel = 200;

    Vector3 moveVec;

    [Header("Components")]
    [SerializeField] Transform targetTransform;
    [SerializeField] Rigidbody rb;

    //--------------------------------------------------

    // 移動関係の入力取得
    void OnMove(InputValue value)
    {
        var axis = value.Get<Vector3>();
        moveVec = new Vector3(axis.x, 0, axis.z);

        print(moveVec);
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude < maxVel) {
            rb.AddForce(moveVec * speed);
            print(rb.velocity.magnitude);
        }
	}
}
