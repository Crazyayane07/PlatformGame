using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int playerScore = 0;
    public Text playerScoreText;
    private const int TO_NEXT_LEVEL_POINTS = 5;
    private const string LEVEL_1 = "Scene_2";
    private const string LEVEL_2 = "Scene_3";
    private const string MAIN_MENU = "Scene_1";

    public object SceneMenager { get; private set; }

    private void Update()
    {
        if (playerScore == TO_NEXT_LEVEL_POINTS && SceneManager.GetActiveScene().name == LEVEL_1)
        {
            playerScore = 0;
            SceneManager.LoadScene(LEVEL_2);
        }
        else if(playerScore == TO_NEXT_LEVEL_POINTS && SceneManager.GetActiveScene().name == LEVEL_2)
        {
            SceneManager.LoadScene(MAIN_MENU);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();
            Destroy(collision.gameObject);
        }
    }
}
