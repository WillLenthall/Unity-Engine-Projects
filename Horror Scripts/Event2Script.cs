using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event2Script : MonoBehaviour
{
    public GameObject playerControl;
    public GameObject door;
    public GameObject monster;
    public GameObject[] lights;
    public Transform[] positions;
    public int step;
    public AudioSource hit;
    public GameObject bgm;
    public GameObject bgs;
    public AudioSource whisper;
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
        bgm.SetActive(false);
        bgs.SetActive(false);
        GetComponent<AudioSource>().Play();
        playerControl.GetComponent<AudioSource>().enabled = false;
        playerControl.GetComponent<CharacterController>().enabled = false;
        door.SetActive(false);
        monster.SetActive(true);
        Invoke("LightSmash", 2);
        Invoke("PlayWhisper", 2);
        Invoke("MoveMonster", 3);
        Invoke("LightSmash", 4);
        Invoke("MoveMonster", 5);
        Invoke("LightSmash", 6);
        Invoke("MoveMonster", 7);
        Invoke("LightSmash", 8);
        Invoke("MoveMonster", 9);  //Skips last expected location to subvert expectaction
        //Invoke("LightSmash", 10);
        Invoke("FinalMonsterLoc", 11);
        Invoke("End", 11.4f);

        GetComponent<BoxCollider>().enabled = false;
        Debug.Log("Trigger");

    }

    void MoveMonster()
    {
        monster.SetActive(true);
        monster.transform.position = positions[step].transform.position;
        step++;
        Debug.Log("MoveMonster");

    }

    void LightSmash()
    {
        AudioSource a = lights[step].GetComponentInChildren<AudioSource>();
        a.Play();
        lights[step].GetComponentInChildren<Light>().enabled = false;
        monster.SetActive(false);
        Debug.Log("LightSmash");

    }

    void FinalMonsterLoc()
    {
        Vector3 pOffset = new Vector3(0,0,0);
        if (SceneManager.GetActiveScene().buildIndex == 1) {
            pOffset = new Vector3(-0.8f, -0.3f, 0f);
        }
        else {
            pOffset = new Vector3(0.8f, -0.3f, 0f);
        }
        monster.SetActive(true);
        monster.transform.position = playerControl.transform.position + pOffset;
        hit.Play();
        //monster.GetComponent<Animator>().SetBool("Attack", true);
        Debug.Log("FinalMonsterLoc");

    }

    void End()
    {
        monster.SetActive(false);
        playerControl.GetComponent<AudioSource>().enabled = true;
        playerControl.GetComponent<CharacterController>().enabled = true;
        bgm.SetActive(true);
        bgs.SetActive(true);
        Debug.Log("end");

    }

    void PlayWhisper()
    {
        whisper.Play();
        Debug.Log("Whisper");

    }
}
