using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour {
    const int START_GAME_BTN = 0;
    const int QUIT_GAME_BTN = 1;

	public void triggerMenuBehaviour(int btnId)
    {
        switch (btnId)
        {
            case (START_GAME_BTN):
                SceneManager.LoadScene("Scene_2");
                PlayerHealth.health = 3;
                break;
            case (QUIT_GAME_BTN):
                Application.Quit();
                break;
            default:
                break;
        }
    }
}
