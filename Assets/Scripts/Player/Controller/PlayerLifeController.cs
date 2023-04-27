using Cysharp.Threading.Tasks;
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

		public bool IsDead { get; private set; }


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

		}

		/// <summary>
		/// �v���C���[�������Ԃ�Ƃ��̏���
		/// </summary>
		public void Revivaled()
		{
			UniTask.Delay(TimeSpan.FromSeconds(deadDuration), cancellationToken: token);		// �ҋ@
		}

    }
}