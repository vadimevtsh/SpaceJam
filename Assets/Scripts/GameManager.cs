using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public static GameManager instance;

    public Text loseText;
    public FloatingTextManager floatingTextManager;

    public float currentOxygen;
    public float maxOxygen;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
          //  Destroy(player.gameObject);
            return;
        }

        PlayerPrefs.DeleteAll();

        instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    public void showText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }


    private void Update()
    {
        isDead();
    }

    private void isDead()
    {
        player = GameObject.Find("spaceman");
        if (player.GetComponent<SpaceMan>().currentOxygen <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Destroy(player);
            loseText.text = "U lose. Suck penis";

        }
    }
}
