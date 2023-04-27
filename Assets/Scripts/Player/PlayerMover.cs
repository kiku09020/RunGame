using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerMover : MonoBehaviour {
        [Header("Parameters")]
        [SerializeField] float speed = 50;
        [SerializeField] float maxVel = 200;

        Vector3 moveVec;

        [Header("Components")]
        [SerializeField] Transform targetTransform;
        [SerializeField] Rigidbody rb;

        public bool IsMoving { get; private set; }

        //--------------------------------------------------

        // ˆÚ“®ŠÖŒW‚Ì“ü—ÍŽæ“¾
        public void OnMove(InputAction.CallbackContext context)
        {
            var axis = context.ReadValue<Vector2>();

            moveVec = new Vector3(axis.x, 0, axis.y);
        }

        void FixedUpdate()
        {
            var vel = new Vector2(rb.velocity.x, rb.velocity.z).magnitude;

            if (vel > .1f) {
                IsMoving = true;
            }

            else {
                IsMoving = false;
            }

            if (rb.velocity.magnitude < maxVel) {
                var forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
                var moveForword = forward * moveVec.z + Camera.main.transform.right * moveVec.x;

                rb.AddForce(moveForword * speed);
            }
        }
    }
}