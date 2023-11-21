using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTransport : MonoBehaviour
{
    public GameObject destination;
    public GameObject player;
    private bool transport;
    public AudioSource audio;
    public int maxTransports;
    public int transports;

    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            Vector3 yOffset = new Vector3(0, -0.8f, 0);
            Vector3 d = destination.transform.position + yOffset;
            player.transform.position = d;

            audio.time = 18;
            audio.Play();
           
            transports += 1;
            if (transports >= maxTransports)
            {
                RemovePortal();
            }
            Debug.Log("teleport");

        }
    }

    void RemovePortal()
    {
       this.gameObject.SetActive(false);
        Debug.Log("removeportal");

    }



}
