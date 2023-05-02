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
        [SerializeField] float speed = 50;              // ���x
        [SerializeField] float maxVel = 200;            // �ő呬�x
        [SerializeField] float moveThreshold = 0.1f;    // �ړ�臒l

        [Header("Effects")]
        [SerializeField] bool enableEffect;
        [SerializeField] ParticleSystem dashParticle;
        [SerializeField] float particleInterval = 0.2f;

        Vector3 moveVec;                                // �ړ��x�N�g��

        [Header("Components")]
        [SerializeField] Transform targetTransform;
        [SerializeField] Rigidbody rb;
        [SerializeField] PlayerCore player;

        /// <summary>
        /// �ړ����Ă��邩�ǂ���
        /// </summary>
        public bool IsMoving { get; private set; }

        float timer;

		//--------------------------------------------------

		// ���͎擾
		public void OnMove(InputAction.CallbackContext context)
        {
            var axis = context.ReadValue<Vector2>();

            moveVec = new Vector3(axis.x, 0, axis.y);
        }

        void FixedUpdate()
        {
            if (!player.IsGoaled && !player.IsDamaged) {
                // Y�������������x�̑傫�����擾
                var vel = new Vector2(rb.velocity.x, rb.velocity.z).magnitude;

                // �ړ�����
                IsMoving = (vel > moveThreshold) ? true : false;

                // �ړ�
                if (rb.velocity.magnitude < maxVel) {
                    // �J��������̃v���C���[�̐��ʕ������擾
                    var forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
                    var moveForword = forward * moveVec.z + Camera.main.transform.right * moveVec.x;

                    // �ړ�
                    rb.AddForce(moveForword * speed);

                    GenerateDashEffect();
                }
            }

            else {
                // �ړ����~
                IsMoving = false;
            }

		}

        // �_�b�V���G�t�F�N�g�̐���
        void GenerateDashEffect()
        {
            // �n��ňړ����Ă���Ƃ��̂ݐ���
            if (IsMoving && player.IsLanding) {
                timer += Time.deltaTime;

                // �C���^�[�o�����Ƃɐ���
                if (timer >= particleInterval) {
                    Instantiate(dashParticle, targetTransform.position, Quaternion.identity);
                    timer = 0;
                }
            }

            // �^�C�}�[���Z�b�g
            else {
                timer = 0;
            }
        }
    }
}