using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Player {
	/// <summary>
	/// プレイヤーの生死関係の制御
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
		/// プレイヤーが死んだときの処理
		/// </summary>
		public void Dead()
		{

		}

		/// <summary>
		/// プレイヤーが生き返るときの処理
		/// </summary>
		public void Revivaled()
		{
			UniTask.Delay(TimeSpan.FromSeconds(deadDuration), cancellationToken: token);		// 待機
		}

    }
}