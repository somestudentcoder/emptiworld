using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("BaseScene", LoadSceneMode.Single);
    }

     public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void MainMenuScene() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
