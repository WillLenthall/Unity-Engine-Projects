using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class JailCell : MonoBehaviour
{
    public GameObject hint;
    public TMP_Text text;
    public GameObject spoon;
    public GameObject wall;
    public GameObject poster;
    public bool inZone = false;
    public AudioSource complete;
    public AudioClip clip;

    // Start is called before the first frame update


    public void Tunnel()
    {
        if (!spoon.GetComponent<GrabbableObject>().GetGrabbed() && wall!= null)
        {
            text.text = "Perhaps you should use a tool.";
            spoon.GetComponent<GrabbableObject>().NeedAsTool();
            GetComponent<AudioSource>().Play();
        }

        else if (spoon.GetComponent<GrabbableObject>().GetGrabbed() && !spoon.GetComponent<GrabbableObject>().SpoonStraight() && wall != null)
        {
            text.text = "It won't work in that condition.";
            GetComponent<AudioSource>().Play();
        }

        else if (spoon.GetComponent<GrabbableObject>().GetGrabbed() && spoon.GetComponent<GrabbableObject>().SpoonStraight() && wall != null)
        {
            text.text = "After a few years you tunnel through the wall.";
            spoon.GetComponent<GrabbableObject>().DontNeedAsTool();
            Destroy(poster); poster = null;
            GetComponent<AudioSource>().clip = clip;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
            Invoke("StopSound", 2.8f);
        }

    }

    public void EnableHint()
    {
        hint.SetActive(true);
    }

    public void DisableHint()
    {
        hint.SetActive(false);
    }

    public void StopSound()
    {
        GetComponent<AudioSource>().Stop();
        complete.Play();
        Destroy(wall); wall = null;
    }
}
