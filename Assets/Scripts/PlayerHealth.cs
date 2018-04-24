using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public static int health = 3;
    public Slider MusicSlider;
    public GameObject deadMenu;

    [SerializeField]
    private TextMesh deathText;
    [SerializeField]
    public Sprite[] heartsSprites;
    [SerializeField]
    public Image HeartCointainer;

    public AudioClip ouch_crack;
    public float enemyJumpPower = 12.5f;

    private void Start()
    {
        deadMenu.SetActive(false);
        HeartCointainer.sprite = heartsSprites[health];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(ouch_crack, transform.position,MusicSlider.value);
            health--;
            HeartCointainer.sprite = heartsSprites[health];
            
             if (health == 0)
            {
                gameObject.SetActive(false);
                deadMenu.SetActive(true);
            }
        }
    }
}
