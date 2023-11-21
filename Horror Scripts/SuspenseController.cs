using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspenseController : MonoBehaviour
{
    public GameObject player;
    public GameObject door;
    AudioSource audio;
    public float distance;
    public float period;
    public GameObject wall;
    public GameObject bgm;
    public GameObject bgs;
    //public Vector3 offset;
    //public float prevX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (period > 0.4 && audio != null)
        {
            distance = Vector3.Distance(player.transform.position, door.transform.position);
            if (distance >24)
            {
                distance = 24;
            }
            audio.time = 12f - distance/2; //* (3f / (distance*2));
            //if (audio.time >14)
            //{
            //    audio.time = 13;
            //}
            period = 0;
            

        }
        period += UnityEngine.Time.deltaTime;
        //if (prevX > player.transform.position.x)
        //{
        //    Vector3 tmpPos = player.transform.position + offset;
        //    wall.transform.position = new Vector3(tmpPos.x, -22.5f, 11.676f);
        //}
        //prevX= player.transform.position.x;
    }

    void OnTriggerEnter(Collider col)
    {
        bgm.SetActive(false);
        bgs.SetActive(false);
        GetComponent<AudioSource>().enabled = true;
        audio = GetComponent<AudioSource>();
        wall.SetActive(true);
        Debug.Log("Trigger");

    }

}
