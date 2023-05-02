using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerMover : MonoBehaviour {
        [Header("Parameters")]
        [SerializeField] float speed = 50;              // 速度
        [SerializeField] float maxVel = 200;            // 最大速度
        [SerializeField] float moveThreshold = 0.1f;    // 移動閾値

        [Header("Effects")]
        [SerializeField] bool enableEffect;
        [SerializeField] ParticleSystem dashParticle;
        [SerializeField] float particleInterval = 0.2f;

        Vector3 moveVec;                                // 移動ベクトル

        [Header("Components")]
        [SerializeField] Transform targetTransform;
        [SerializeField] Rigidbody rb;
        [SerializeField] PlayerCore player;

        /// <summary>
        /// 移動しているかどうか
        /// </summary>
        public bool IsMoving { get; private set; }

        float timer;

		//--------------------------------------------------

		// 入力取得
		public void OnMove(InputAction.CallbackContext context)
        {
            var axis = context.ReadValue<Vector2>();

            moveVec = new Vector3(axis.x, 0, axis.y);
        }

        void FixedUpdate()
        {
            if (!player.IsGoaled && !player.IsDamaged) {
                // Y軸を除いた速度の大きさを取得
                var vel = new Vector2(rb.velocity.x, rb.velocity.z).magnitude;

                // 移動判定
                IsMoving = (vel > moveThreshold) ? true : false;

                // 移動
                if (rb.velocity.magnitude < maxVel) {
                    // カメラからのプレイヤーの正面方向を取得
                    var forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
                    var moveForword = forward * moveVec.z + Camera.main.transform.right * moveVec.x;

                    // 移動
                    rb.AddForce(moveForword * speed);

                    GenerateDashEffect();
                }
            }

            else {
                // 移動中止
                IsMoving = false;
            }

		}

        // ダッシュエフェクトの生成
        void GenerateDashEffect()
        {
            // 地上で移動しているときのみ生成
            if (IsMoving && player.IsLanding) {
                timer += Time.deltaTime;

                // インターバルごとに生成
                if (timer >= particleInterval) {
                    Instantiate(dashParticle, targetTransform.position, Quaternion.identity);
                    timer = 0;
                }
            }

            // タイマーリセット
            else {
                timer = 0;
            }
        }
    }
}