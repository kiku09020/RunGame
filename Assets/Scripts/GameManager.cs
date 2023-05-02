using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameInput input;

	//--------------------------------------------------

	private void Awake()
	{
		input = new GameInput();
		input.Reset.Reset.performed += OnReset;

		input.Enable();
	}

	// ���݂̃V�[�����ēǂݍ���
	void OnReset(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }
}
