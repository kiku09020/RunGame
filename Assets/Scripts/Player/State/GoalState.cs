using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIManager;

namespace Player.State {
    public class GoalState : PlayerStateBase {

		[Header("Effects")]
		[SerializeField] ParticleSystem particle;
		//--------------------------------------------------

		public override void OnEnter()
		{
			animator.SetBool("Goaled", true);

			UIManager.UIManager.ShowUIGroup<GoalUIGroup>();			// UI表示

			Instantiate(particle, transform.position, Quaternion.identity);		// パーティクル生成
		}

		public override void OnUpdate()
		{

		}

		public override void OnExit()
		{

		}

	}
}