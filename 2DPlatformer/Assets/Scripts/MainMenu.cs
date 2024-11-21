using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Optname;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Optionsmenu()
    {
        SceneManager.LoadScene(Optname);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quit");
    }
}