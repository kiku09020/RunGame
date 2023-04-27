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
        [SerializeField] PlayerCore player;
 
        public bool IsJumping { get; private set; }
        public bool IsFalling { get; private set; }

        //--------------------------------------------------

        void Awake()
        {

        }

		private void FixedUpdate()
		{
            var velY=Mathf.Ceil(rb.velocity.y);

			// 0以上だったらfallingをfalse
			if (IsFalling && player.IsLanding) {
                if (velY >= 0) {
				    IsFalling = false;
                }
			}

			// ジャンプ中にvelocityのyが0より小さくなったら落下フラグ立てる
			if (IsJumping) {
                if (velY < 0) {
                    IsFalling = true;
                    IsJumping = false;
                }
            }
		}

		public void OnJump(InputAction.CallbackContext context)
        {
            if (player.IsLanding) {
                player.State.StateTransition<JumpState>();
                rb.AddForce(Vector3.up * jumpForce);
                IsJumping = true;
            }
        }
    }
}