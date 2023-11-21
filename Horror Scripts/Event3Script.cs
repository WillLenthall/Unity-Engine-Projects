using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3Script : MonoBehaviour
{
    public GameObject oldDoor;
    public GameObject newDoor;
    public GameObject wall;
    public GameObject p2;
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
        oldDoor.GetComponent<BoxCollider>().enabled = false;
        newDoor.SetActive(true);
        p2.SetActive(true);
        wall.SetActive(false);
        Debug.Log("Trigger");

    }

}
