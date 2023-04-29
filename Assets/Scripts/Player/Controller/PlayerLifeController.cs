using Cysharp.Threading.Tasks;
using Player.State;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Player {
	/// <summary>
	/// �v���C���[�̐����֌W�̐���
	/// </summary>
	public class PlayerLifeController : MonoBehaviour {

		[Header("Parameters")]
		[SerializeField] float deadDuration = 3;
		[SerializeField] Vector3 revivaledPoint;

		[Header("Components")]
		[SerializeField] GameObject playerObj;
		[SerializeField] PlayerStateMathine state;
		[SerializeField] PlayerDamageChecker damage;

		CancellationToken token;

        //--------------------------------------------------

        private void Awake()
        {
			token = this.GetCancellationTokenOnDestroy();
        }

        /// <summary>
        /// �v���C���[�����񂾂Ƃ��̏���
        /// </summary>
        public void Dead()
		{
			Revivaled().Forget();
		}

		/// <summary>
		/// �v���C���[�������Ԃ�Ƃ��̏���
		/// </summary>
		public async UniTask Revivaled()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(deadDuration), false, PlayerLoopTiming.FixedUpdate,token);        // �ҋ@

			playerObj.transform.position = revivaledPoint;		// �����ʒu�Ƀ��[�v
			damage.IsDamaged = false;							// �ړ����false�ɂ���

			state.StateTransition<IdleState>();					// ��ԑJ��

			print("revivaled");
		}
    }
}