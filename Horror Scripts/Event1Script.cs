using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1Script : MonoBehaviour
{
    public GameObject creature;
    public GameObject creatureHead;
    
    public GameObject player;
    public Transform door;
    public Transform pos;
    public Transform pos2;
    public Transform pos3;
    public Transform creaturePos;

    public AudioClip[] footsteps;
    public AudioClip hit;
    public GameObject creak;
    public AudioClip suspense;

    public GameObject bgm;
    public GameObject bgs;


    UnityEngine.AI.NavMeshAgent agent1;
    UnityEngine.AI.NavMeshAgent agent2;
    UnityEngine.AI.NavMeshAgent playerCamAgent;
    Animator creatureAnim;
    AudioSource audio;

    void Start()
    {
        creatureAnim = creature.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.clip = suspense;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            bgs.SetActive(false);
            //audio.Play();
            movePlayer();
            Invoke("movePlayer2", 2);
            Invoke("PlayCreak", 2.5f);
            Invoke("StopCreak", 4);
            Invoke("turnHead", 5.5f);
            Invoke("moveCreature", 7.5f);
            Invoke("playerRetreat", 8f);
            Invoke("returnControl", 9.5f);
            GetComponent<BoxCollider>().enabled = false;
            Debug.Log("Trigger");

        }
    }

    void movePlayer()
    {
        player.GetComponent<AudioSource>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        agent1 = player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent1.SetDestination(pos.position);
        Invoke("playFootsteps", 0.5f);
        //Invoke("playFootsteps", 1);
        Invoke("playFootsteps", 1);
        Debug.Log("MovePlayer");

    }

    void movePlayer2()
    {
        
        agent1.SetDestination(pos2.position);
        Debug.Log("MovePlayer2");

    }

    void moveCreature()
    {
        agent2 = creature.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent2.SetDestination(creaturePos.position);
        creatureAnim.SetBool("TurnHead", false);
        creatureAnim.SetBool("Move", true);
        Debug.Log("MoveCreature");

    }

    void playerRetreat()
    {
        agent1.baseOffset = 0;
        agent1.SetDestination(pos3.position);
        Debug.Log("PlayerRetreat");

    }

    void returnControl()
    {
        for (float i = 0; i < 20; i++) { 
            Invoke("shutDoor", 0.02f*i);
        }

        Invoke("stand", 1);
        agent2.enabled = false;
        creatureAnim.SetBool("Move", false);

        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<AudioSource>().enabled = true;
        bgm.SetActive(true);
        bgs.SetActive(true);
        Debug.Log("ReturnControl");

    }

    void shutDoor()
    {
        door.transform.Rotate(0, -1, 0);
        Debug.Log("ShutDoor");


    }

    void stand()
    {
        agent1.baseOffset = 1;
        agent1.enabled = false;
        Debug.Log("Stand");

    }

    void turnHead()
    {
        bgm.SetActive(false);
        creatureAnim.SetBool("TurnHead", true);
        audio.clip = hit;
        audio.time = 1.8f;
        audio.Play();
        //audio.time = 0;
        Debug.Log("TurnHead");

    }

    void playFootsteps()
    {
        AudioSource a;
        a = door.GetComponent<AudioSource>();
        int n = 1;
        a.clip = footsteps[n];
        a.PlayOneShot(a.clip);
        footsteps[n] = footsteps[0];
        Debug.Log("FootSteps");

    }

    void PlayCreak()
    {
        creak.GetComponent<AudioSource>().Play();
        Debug.Log("creak");

    }

    void StopCreak()
    {
        creak.GetComponent<AudioSource>().Stop();
        Debug.Log("creakEnd");

    }
}
