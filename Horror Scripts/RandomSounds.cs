using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    public AudioClip[] sounds;
    public int iterator;
    public float period;
    public float random;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(15, 26);
    }

    // Update is called once per frame
    void Update()
    {
        if (period > random)
        {
            random = Random.Range(15, 26);
                       
            if (iterator >=sounds.Length)
            {
                iterator = 0;
            }
            GetComponent<AudioSource>().clip = sounds[iterator];
            GetComponent<AudioSource>().Play();
            iterator++;
            period = 0;
            Debug.Log("soundeffect");

        }
        period += UnityEngine.Time.deltaTime;

    }
}
