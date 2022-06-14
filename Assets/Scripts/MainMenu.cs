using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This is a class that is responsible for the main menu.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Method that is called when user clicks on Play button in the menu.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Method that is called when user clicks on Quit button in the menu.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
