using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    Animator doorAnim;

    //public AudioClip doorSound;
    // Start is called before the first frame update
    void Start()
    {
        doorAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        doorAnim.SetBool("Open", true);
        GetComponent<AudioSource>().time = 0f;

        GetComponent<AudioSource>().Play();
        Invoke("StopSound", 1);

        Debug.Log("Open");

    }

    void OnTriggerExit(Collider col)
    {
        GetComponent<AudioSource>().time = 1.4f;

        GetComponent<AudioSource>().Play();
        doorAnim.SetBool("Open", false);
        Debug.Log("Close");

    }

    void StopSound()
    {
        GetComponent<AudioSource>().Stop();
        Debug.Log("SoundStopped");

    }
}
