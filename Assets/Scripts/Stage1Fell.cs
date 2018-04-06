using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1Fell : MonoBehaviour {
    const float TIME_TO_RESPAWN_1 = 0.3f;
    const string LEVEL_1_SCENE = "Scene_2";
    const float LEVEL_1_X = -7.72f;
    const float LEVEL_1_Y = -1.12f;
    const string LEVEL_2_SCENE = "Scene_3";
    const float LEVEL_2_X = -16.97f;
    const float LEVEL_2_Y = 0.32f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // StartCoroutine(Respawn(collision, SceneManager.GetActiveScene().name));
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    IEnumerator Respawn(Collision2D collision, string level)
    {
        yield return new WaitForSeconds(TIME_TO_RESPAWN_1);
        if(level == LEVEL_1_SCENE)
        {
            collision.transform.position = new Vector2(LEVEL_1_X, LEVEL_1_Y);
        }
        if (level == LEVEL_2_SCENE)
        {
            collision.transform.position = new Vector2(LEVEL_2_X, LEVEL_2_Y);
        }
    }
}
