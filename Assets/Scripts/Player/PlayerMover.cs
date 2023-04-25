using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
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
    }

    // カメラからみたプレイヤーへの進行方向に進


    void FixedUpdate()
    {
        if (rb.velocity.magnitude < maxVel) {
            var forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            var moveForword = forward * moveVec.z + Camera.main.transform.right * moveVec.x;

			rb.AddForce(moveForword * speed);

   //         // 正面方向 * 正規化された入力ベクトルの大きさ
   //         var targetVec = targetTransform.rotation * moveVec;

			//rb.AddForce(targetVec * speed);
        }
	}
}
