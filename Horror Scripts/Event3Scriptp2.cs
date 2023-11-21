using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3Scriptp2 : MonoBehaviour
{
    public GameObject portal;
    public GameObject wall;
    public GameObject newDoor;
    public GameObject p3;

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
        newDoor.SetActive(true);
        portal.SetActive(true);
        wall.SetActive(false);
        if (p3 != null)
        {
            p3.SetActive(true);
        }
        Debug.Log("Trigger");

    }
}
