using Cysharp.Threading.Tasks;
using Player.State;
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
		[SerializeField] Vector3 revivaledPoint;

		[Header("Components")]
		[SerializeField] GameObject playerObj;
		[SerializeField] PlayerStateMathine state;
		[SerializeField] PlayerDamageChecker damage;

		[Header("Effects")]
		[SerializeField] ParticleSystem particle;

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
			Instantiate(particle, transform.position, Quaternion.identity);		// パーティクル生成

			Revivaled().Forget();		// 生き返り処理
		}

		/// <summary>
		/// プレイヤーが生き返るときの処理
		/// </summary>
		async UniTask Revivaled()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(deadDuration), false, PlayerLoopTiming.FixedUpdate,token);        // 待機

			playerObj.transform.position = revivaledPoint;		// 初期位置にワープ
			damage.IsDamaged = false;							// 移動後にfalseにする

			state.StateTransition<IdleState>();					// 状態遷移
		}
    }
}