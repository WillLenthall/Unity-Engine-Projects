using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void nextVer()
    {
        
        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);

        }
        else
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Begin()
    {
        this.gameObject.SetActive(false);
    }
}
