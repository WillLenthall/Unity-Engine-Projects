using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public GameObject player;
    public AudioSource menuSound;
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        menuSound.Play();
    }
    public void VolumeDown()
    {
        if (AudioListener.volume>0.09)
        {
            AudioListener.volume -= 0.1f;
            menuSound.Play();

        }
    }
    
    public void VolumeUp()
    {
        if (AudioListener.volume<0.91)
        {
            AudioListener.volume += 0.1f;
            menuSound.Play();

        }
    }

    public void Resume()
    {
        transform.parent.gameObject.SetActive(false);
        player.GetComponent<LookSpawnTeleport>().ToggleMenuBool();
        menuSound.Play();

    }
}
