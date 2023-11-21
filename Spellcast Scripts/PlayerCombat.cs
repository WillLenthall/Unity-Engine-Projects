using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerCombat : MonoBehaviour
{
    private int HP;
    private Boolean alive;
    public Boolean onFire = false;
    public int flameDuration = 0;

    public AudioClip earthHitSound;
    public AudioClip fireHitSound;
    public AudioClip onFireSound;

    public GameObject victoryScreen;


    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        HP = 100;

        InvokeRepeating("burning", 1f, 1f);  //1s delay, repeat every 1s

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dealDamage(int dmg)
    {
        HP -= dmg;
        if (HP <=0)
        {
            HP = 0;
            alive = false;

            Invoke("death", 2f);

        }
    }

    public void death()
    {
        if (gameObject.tag == "MainCamera")
        {
            victoryScreen.GetComponentInChildren<TMP_Text>().text = "Defeated!";
        }
        Time.timeScale = 0;
        victoryScreen.SetActive(true);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "BigStone")
        {
            GetComponent<AudioSource>().PlayOneShot(earthHitSound);
            dealDamage(25);

        }

        if (col.gameObject.tag == "SmallStone")
        {
            GetComponent<AudioSource>().PlayOneShot(earthHitSound);
            dealDamage(15);

        }

        if (col.gameObject.tag == "LargeFire")
        {
            GetComponent<AudioSource>().PlayOneShot(fireHitSound);
            dealDamage(15);
            ignite();

        }

        if (col.gameObject.tag == "Fire")
        {
            GetComponent<AudioSource>().PlayOneShot(fireHitSound);
            dealDamage(20);
            ignite();

        }
        if (col.gameObject.tag == "Lava")
        {
            
            ignite();

        }

        if (col.gameObject.tag == "FireClass")
        {
            transform.parent.GetComponentInChildren<Caster>().setFireMage();

        }

        if (col.gameObject.tag == "EarthClass")
        {
            transform.parent.GetComponentInChildren<Caster>().setEarthMage();
        }


    }

    public void ignite()
    {
        onFire = true;
        flameDuration = 3;
        GetComponent<AudioSource>().PlayOneShot(onFireSound);
        GetComponentInChildren<ParticleSystem>().Play();
    }

    void burning()
    {
        if (onFire == true) {
            dealDamage(5);
            flameDuration--;
           
            if (flameDuration <= 0)
            {
                onFire = false;
                GetComponentInChildren<ParticleSystem>().Stop();
            }
        }
    }

    public Boolean isAlive()
    {
        return alive;
    }

    public int getHP()
    {
        return HP;
    }
}
