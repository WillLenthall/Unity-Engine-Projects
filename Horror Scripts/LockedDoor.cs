using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
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
        GetComponent < AudioSource>().time = 1.4f;
        GetComponent < AudioSource>().Play();
        Debug.Log("Trigger");

    }

}
