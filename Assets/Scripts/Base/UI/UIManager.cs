using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManager {
	public class UIManager : MonoBehaviour {
		// inspector List
		[SerializeField, Tooltip("���߂ɗL���ɂȂ�UIGroup")] UIGroupBase startUIGroup;
		[SerializeField] List<UIGroupBase> _uiGroupList = new List<UIGroupBase>();

		// static List
		public static readonly List<UIGroupBase> uiGroupList = new List<UIGroupBase>();

		// ���ݗL����UIGroup
		static UIGroupBase currentUIGroup;

		// UIGroup�̗���
		static Stack<UIGroupBase> histroy = new Stack<UIGroupBase>();

		private void Awake()
		{
			foreach (var uiGroup in _uiGroupList) {
				uiGroup.Hide();
				uiGroup.Initialize();
				uiGroupList.Add(uiGroup);

				// ����UIGroup��\��
				if (startUIGroup) {
					ShowUIGroup(startUIGroup);
				}
			}
		}

		private void OnDestroy()
		{
			uiGroupList.Clear();
		}

		/// <summary>
		/// <typeparamref name="T"/>�^��UIGroup���擾����
		/// </summary>
		/// <typeparam name="T">UIGroup�̌^</typeparam>
		/// <returns><typeparamref name="T"/>�^��UIGroup�̃C���X�^���X</returns>
		public static T GetUIGroup<T>() where T : UIGroupBase
		{
			// T�^��UIGroup����������
			foreach (var uiGroup in uiGroupList) {
				if (uiGroup is T targetUI) {
					return targetUI;
				}
			}

			return null;
		}

		/// <summary>
		/// UIGroup��\������
		/// </summary>
		/// <typeparam name="T">UIGroup�̌^</typeparam>
		/// <param name="remember">�����Ɏc����</param>
		public static void ShowUIGroup<T>(bool remember = true) where T : UIGroupBase
		{
			foreach (var uiGroup in uiGroupList) {
				if (uiGroup is T) {
					if (currentUIGroup) {
						// �����Ɏc���ꍇ�AStack�ɒǉ�
						if (remember) {
							histroy.Push(currentUIGroup);
						}

						currentUIGroup.Hide();      // ���݂�UI���\���ɂ���
					}

					uiGroup.Show();                 // UI�\��
					currentUIGroup = uiGroup;       // ���݂�UI���w�肳�ꂽUI�ɂ���

					ShowCommon();
					return;
				}
			}
		}

		/// <summary>
		/// UIGroup��\������
		/// </summary>
		/// <param name="uiGroup">�\������UIGroup�̃C���X�^���X</param>
		public static void ShowUIGroup(UIGroupBase uiGroup)
		{
			if (currentUIGroup) {
				histroy.Push(currentUIGroup);
				currentUIGroup.Hide();
			}

			uiGroup.Show();
			currentUIGroup = uiGroup;

			ShowCommon();
		}

		/// <summary>
		/// UIGroup��\������
		/// </summary>
		/// <param name="uiGroup">�\������UIGroup�̃C���X�^���X</param>
		/// <param name="remember">�����Ɏc����</param>
		public static void ShowUIGroup(UIGroupBase uiGroup, bool remember = true)
		{
			if (currentUIGroup) {
				if (remember) {
					histroy.Push(currentUIGroup);
				}

				currentUIGroup.Hide();
			}

			uiGroup.Show();
			currentUIGroup = uiGroup;

			ShowCommon();
		}

		/// <summary>
		/// ��O��UIGroup��\������
		/// </summary>
		public static void ShowLastUIGroup()
		{
			if (histroy.Count != 0) {
				ShowUIGroup(histroy.Pop(), false);      // ����������o���ĕ\��
			}
		}

		/// <summary>
		/// �S�Ă�UI���\���ɂ���
		/// </summary>
		public static void HideAllUIGroups()
		{
			foreach (var uiGroup in uiGroupList) {
				uiGroup.Hide();
				currentUIGroup = null;      // ���݂�UI�����Z�b�g
			}
		}

		/// <summary>
		/// ���������Z�b�g����
		/// </summary>
		public static void ResetUIHistory()
		{
			histroy.Clear();
		}

		//-------------------------------------------
		// ���ʏ���
		static void ShowCommon()
		{
			print($"{nameof(currentUIGroup)}={currentUIGroup}");
		}
	}
}