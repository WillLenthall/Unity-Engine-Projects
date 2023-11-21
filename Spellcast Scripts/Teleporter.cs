using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject player;
    public GameObject demon;

    public GameObject destination;
    public AudioClip teleSound;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        

        if (col.gameObject.name == "FPSController")
        {
            
            player.transform.position = destination.transform.position;
            demon.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(teleSound);
            GetComponent<AudioSource>().Play();

        }
    }
}
