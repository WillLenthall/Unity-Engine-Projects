using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3Scriptp3 : MonoBehaviour
{

    public GameObject creature;
    public GameObject player;
    public GameObject playerSecondary;
    AudioSource audio;
    public AudioSource suspense;
    public GameObject wall;
    public GameObject menu;
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.time = 15.5f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<AudioSource>().enabled = false;
        suspense.Stop();
        Invoke("SpawnCreature",1);
        Invoke("StopSound", 1.5f);
        Invoke("Menu", 1.5f);
        Debug.Log("Trigger");

    }

    void SpawnCreature()
    {
        Vector3 pOffset = new Vector3(0.8f, 0f, 0f);
        wall.SetActive(false);
        creature.SetActive(true);
        playerSecondary.SetActive(true);
        playerSecondary.transform.position = player.transform.position;
        player.SetActive(false);
        creature.transform.position = playerSecondary.transform.position + pOffset;
        playerSecondary.transform.localEulerAngles = new Vector3(0,90, 0);
        audio.Play();
        Debug.Log("SpawnCreature");

    }

    void StopSound()
    {
        audio.Stop();
        Debug.Log("audioStop");

    }

    void Menu()
    {
        menu.SetActive(true);
        playerSecondary.SetActive(false);
        player.SetActive(true);
        Debug.Log("menu");


    }
}
