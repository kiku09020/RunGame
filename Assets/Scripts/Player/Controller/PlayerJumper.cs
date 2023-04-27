using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Player.State;

namespace Player {
    public class PlayerJumper : MonoBehaviour {
        [Header("Parameters")]
        [SerializeField] float jumpForce = 300;

        [Header("Components")]
        [SerializeField] Rigidbody rb;
        [SerializeField] PlayerLandingChecker landChecker;
        [SerializeField] PlayerStateMathine state;

        public bool IsJumping { get; private set; }
        public bool IsFalling { get; private set; }

        //--------------------------------------------------

        void Awake()
        {

        }

		private void FixedUpdate()
		{
            var velY=Mathf.Ceil(rb.velocity.y);

			// 0�ȏゾ������falling��false
			if (IsFalling && landChecker.IsLanding) {
                if (velY >= 0) {
				    IsFalling = false;
                }
			}

			// �W�����v����velocity��y��0��菬�����Ȃ����痎���t���O���Ă�
			if (IsJumping) {
                if (velY < 0) {
                    IsFalling = true;
                    IsJumping = false;
                }
            }
		}

		public void OnJump(InputAction.CallbackContext context)
        {
            if (landChecker.IsLanding) {
                state.StateTransition<JumpState>();
                rb.AddForce(Vector3.up * jumpForce);
                IsJumping = true;
            }
        }
    }
}