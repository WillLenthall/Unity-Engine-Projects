using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ver2Adjuster : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject obstruction;
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
        Invoke("RemoveBlocks", 0.5f);
        Debug.Log("Trigger");

    }

    void RemoveBlocks()
    {
        door1.SetActive(false);
        door2.SetActive(false);
        obstruction.transform.position = new Vector3(-22.2306633f, -9.20520401f, 12.0270004f);
        Debug.Log("pathclear");

    }

}
