using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This is a class responsible for managing the game.
/// </summary>
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

    /// <summary>
    /// Method that shows floating text, using floatingTextManager.
    /// </summary>
    /// <param name="msg">Message to be shown</param>
    /// <param name="fontSize">Font Size</param>
    /// <param name="color">Color of the message</param>
    /// <param name="position">Position on the screen</param>
    /// <param name="motion">Motion</param>
    /// <param name="duration">Duration</param>
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }


    private void Update()
    {
        IsDead();
    }

    /// <summary>
    /// Method that determines whether the player is dead or not.
    /// </summary>
    private void IsDead()
    {
        player = GameObject.Find("spaceman");
        if (player.GetComponent<SpaceMan>().CurrentOxygen <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Destroy(player);
            loseText.text = "You lost";

        }
    }
}
