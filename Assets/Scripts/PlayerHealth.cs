using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public static int health = 3;

    public GameObject deadMenu;

    [SerializeField]
    private TextMesh deathText;
    [SerializeField]
    public Sprite[] heartsSprites;
    [SerializeField]
    public Image HeartCointainer;

    private void Start()
    {
        deadMenu.SetActive(false);
    }
    private void Update()
    {
        HeartCointainer.sprite = heartsSprites[health];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            if(health == 0)
            {
                HeartCointainer.sprite = heartsSprites[health];
                gameObject.SetActive(false);
                deadMenu.SetActive(true);
            }
        }
    }
}
