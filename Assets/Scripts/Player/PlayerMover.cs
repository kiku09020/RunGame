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

    // �ړ��֌W�̓��͎擾
    void OnMove(InputValue value)
    {
        var axis = value.Get<Vector3>();

        moveVec = new Vector3(axis.x, 0, axis.z);
    }

    // �J��������݂��v���C���[�ւ̐i�s�����ɐi


    void FixedUpdate()
    {
        if (rb.velocity.magnitude < maxVel) {
            var forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            var moveForword = forward * moveVec.z + Camera.main.transform.right * moveVec.x;

			rb.AddForce(moveForword * speed);

   //         // ���ʕ��� * ���K�����ꂽ���̓x�N�g���̑傫��
   //         var targetVec = targetTransform.rotation * moveVec;

			//rb.AddForce(targetVec * speed);
        }
	}
}
