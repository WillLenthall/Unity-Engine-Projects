using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

public class Headshot : MonoBehaviour
{
    PlayerCombat script;
    // Start is called before the first frame update
    void Start()
    {
        script = transform.parent.gameObject.GetComponent<PlayerCombat>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "BigStone")
        {
            script.dealDamage(40);
            transform.parent.GetComponent<AudioSource>().PlayOneShot(script.earthHitSound);

        }

        if (col.gameObject.tag == "SmallStone")
        {
            script.dealDamage(25);
            transform.parent.GetComponent<AudioSource>().PlayOneShot(script.earthHitSound);

        }

        if (col.gameObject.tag == "LargeFire")
        {
            script.dealDamage(30);
            transform.parent.GetComponent<AudioSource>().PlayOneShot(script.fireHitSound);
            script.ignite();
        }
    }
}
