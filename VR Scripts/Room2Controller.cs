using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room2Controller : MonoBehaviour
{
    public TMP_Text item1;
    public TMP_Text item2;
    public TMP_Text item3;
    public bool foundHead = false;
    public bool foundFish = false;
    public bool foundGun = false;
    public bool triggered = false;
    public GameObject wall;
    public AudioClip[] clips;
    public AudioSource complete;
    public GameObject infoTextHead;
    public GameObject infoTextFish;
    public GameObject infoTextGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!triggered && foundFish && foundGun && foundHead)
        {
            Invoke("OpenDoor", 2);
        }
    }

    public void FoundHead()
    {
        item1.text = item1.text + "  -  Found";
        foundHead = true;
        GetComponent<AudioSource>().clip = clips[0];
        GetComponent<AudioSource>().Play();
        infoTextHead.SetActive(true);
    }

    public void FoundFish()
    {
        item2.text = item2.text + "  -  Found";
        foundFish = true;
        GetComponent<AudioSource>().clip = clips[1];
        GetComponent<AudioSource>().time = 4;
        GetComponent<AudioSource>().Play();
        infoTextFish.SetActive(true);
    }

    public void FoundGun()
    {
        item3.text = item3.text + "  -  Found";
        foundGun = true;
        GetComponent<AudioSource>().clip = clips[2];
        GetComponent<AudioSource>().Play();
        infoTextGun.SetActive(true);
    }

    void OpenDoor()
    {
        triggered = true;
        Destroy(wall); 
        wall = null;
        complete.Play();
    }

}
