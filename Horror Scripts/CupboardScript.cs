using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardScript : MonoBehaviour
{
    public GameObject portal;
    public GameObject player;
    public bool rayEnabled;
    RaycastHit hit;
    public GameObject[] dolls;
    public AudioSource laugh;
    // Start is called before the first frame update
    void Start()
    {
        rayEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rayEnabled)
        {
            Debug.DrawRay(player.transform.position, player.transform.forward * 2);
            if (Physics.Raycast(player.transform.position, player.transform.forward,
            out hit, 2))
            {
                if (hit.collider.gameObject.tag == "look")
                {
                    portal.SetActive(true);
                    for (int i = 0; i<4;  i++)
                    {
                        dolls[i].transform.localEulerAngles = new Vector3(-90, 0, 0);
                    }
                    laugh.Play();
                    rayEnabled = false;
                    //this.gameObject.SetActive(false);
                    Debug.Log("RayCollision");

                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Invoke("EnableRay", 1.5f);
        GetComponent<BoxCollider>().enabled = false;
        Debug.Log("Triggered");
    }


    void EnableRay()
    {
        rayEnabled = true;
        Debug.Log("RayEnabled");

    }
}
