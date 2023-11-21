using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject UI;
    public TMP_Text text;
    public bool triggered = false;
    public GameObject wall;
    public AudioSource complete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableUI()
    {
        if (UI != null)
        {
            UI.SetActive(true);
            if (!triggered)
            {
                Invoke("hintText", 10);
                triggered = true;
            }
        }
    }

    public void disableUI()
    {
        if (UI != null)
        {
            UI.SetActive(false);
        }
    }

    public void hintText()
    {
        if (UI != null)
        {
            text.text = "It is not the spoon that bends. It is only yourself";
        }
    }

    public void completedText()
    {
        Destroy(UI); UI = null;
        Destroy(wall);
        complete.Play();
    }

}
