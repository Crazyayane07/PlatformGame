using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour {
    const int YES = 0;
    const int NO = 1;

    public void triggerMenu(int btnId)
    {
        switch (btnId)
        {
            case (YES):
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                PlayerHealth.health = 3;
                break;
            case (NO):
                SceneManager.LoadScene("Scene_1");
                break;
            default:
                break;
        }
    }
}
