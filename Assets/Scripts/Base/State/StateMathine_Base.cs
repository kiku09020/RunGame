using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.State {
    public class StateMathine_Base<T> : MonoBehaviour where T : State_Base {

        [SerializeField] T initState;
        [SerializeField] protected List<T> states = new List<T>();

		/// <summary>
		/// ���݂̏��
		/// </summary>
		public T NowState { get; protected set; }

		//--------------------------------------------------

		protected void Awake()
		{
			AllStatesInit();
		}

		private void FixedUpdate()
		{
			NowState.OnUpdate();

			print(NowState);
		}

		/// <summary>
		/// ���ׂĂ̏�Ԃ̋��ʂ̏�����
		/// </summary>
		protected virtual void AllStatesInit(){}

		/// <summary>
		/// ������ԃZ�b�g�A�b�v
		/// </summary>
		public void StateInit()
		{
			NowState = initState;
			NowState.OnEnter();
		}

		//--------------------------------------------------

		/// <summary>
		/// ���݂̏�Ԃ̍X�V����
		/// </summary>
		public void StateUpdate()
		{
			NowState.OnUpdate();
		}

		//--------------------------------------------------
		/// <summary>
		/// ��ԑJ��
		/// </summary>
		/// <param name="state">���̏��</param>
		public void StateTransition(T state)
		{
			NowState.OnExit();
			NowState = state;
			NowState.OnEnter();
		}

		/// <summary>
		/// ��ԑJ��
		/// </summary>
		public void StateTransition<State>() where State : T
		{
			StateTransition(GetState<State>());
		}

		//--------------------------------------------------

		// State����
		void CheckState<State>(Action<State> action) where State : T
		{
			foreach (var state in states) {
				if (state is State targetState) {
					action?.Invoke(targetState);
				}
			}
		}

		/// <summary>
		/// �w�肵��<typeparamref name="State"/>������΁A�����Ԃ�
		/// </summary>
		/// <typeparam name="State">�ړI�̏��</typeparam>
		/// <returns>�w�肳�ꂽ<typeparamref name="State"/></returns>
		public State GetState<State>() where State : T
		{
			State state = default(State);

			CheckState<State>((targetState) => {
				state = targetState;
			});

			return state;
		}

		/// <summary>
		/// ���݂̏�Ԃ��w�肳�ꂽ��Ԃƈ�v���Ă��邩�ǂ���
		/// </summary>
		public bool CheckNowState<State>() where State:T
		{
			State state = default(State);

			if (NowState == state) {
				return true;
			}

			return false;
		}
	}
}