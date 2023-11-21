using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(sceneIndex);

    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void hideMenu()
    {
        transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
