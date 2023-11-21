using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Caster : MonoBehaviour
{
    public Rigidbody longRangeFirePrefab;
    public Rigidbody shortRangeFirePrefab;
    public Boolean fireMage;


    public Rigidbody longRangeEarthPrefab;
    public Rigidbody shortRangeEarthPrefab;
    public Boolean earthMage;

    public int lrCD = 0;
    public int srCD = 0;

    public AudioClip fireSpellLarge;
    public AudioClip earthSpellLarge;

    public float castSpeed = 10.0f;

    public GameObject cooldownUI;
    public GameObject classUI;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CooldownCounter", 1f, 1f);  //1s delay, repeat every 1s

        earthMage = true;
        fireMage = false;
        classUI.GetComponent<TMP_Text>().color = Color.green;
        classUI.GetComponent<TMP_Text>().text = "Earth Mage";
    }

    // Update is called once per frame
    void Update()
    {
        cooldownUI.GetComponent<TMP_Text>().text = "Cooldowns- Primary: "+ lrCD + "s Secondary: "+ srCD + "s";
        if (Input.GetButtonDown("Fire1"))
        {
            Invoke("spell", 1f);
            
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Invoke("shortSpell", 1f);
        }

    }

    void CooldownCounter()
    {
        if (lrCD >0)
        {
            lrCD--;
        }
        if (lrCD < 0)
        {
            lrCD = 0;
        }

        if (srCD > 0)
        {
            srCD--;
        }
        if (srCD < 0)
        {
            srCD = 0;
        }


    }

    void spell()
    {
        if (lrCD == 0 && earthMage == true)
        {
            Rigidbody newSpell = Instantiate(longRangeEarthPrefab, transform.position, transform.rotation) as Rigidbody;
            newSpell.velocity = transform.forward * castSpeed;
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), newSpell.GetComponent<Collider>(), true);
            GetComponent<AudioSource>().PlayOneShot(earthSpellLarge);

            lrCD = 3;
        }

        else if (lrCD == 0 && fireMage == true)
        {
            Rigidbody newSpell = Instantiate(longRangeFirePrefab, transform.position, transform.rotation) as Rigidbody;
            newSpell.velocity = transform.forward * castSpeed;
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), newSpell.GetComponent<Collider>(), true);
            GetComponent<AudioSource>().PlayOneShot(fireSpellLarge);

            lrCD = 3;
        }

        
    }

    void shortSpell()
    {
        if (srCD == 0 && earthMage == true)
        {
            srCD = 3;
            smallEarthProjectile();
            Invoke("smallEarthProjectile", 0.3f);
            Invoke("smallEarthProjectile", 0.6f);
        }

        if (srCD == 0 && fireMage == true)
        {

            Rigidbody newSpell = Instantiate(shortRangeFirePrefab, transform.position, transform.rotation) as Rigidbody;
            newSpell.GetComponent<ParticleSystem>().Play();
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), newSpell.GetComponent<Collider>(), true);
            GetComponent<AudioSource>().PlayOneShot(fireSpellLarge);

            srCD = 3;
        }

    }

    void smallEarthProjectile()
    {
        Rigidbody newSpell = Instantiate(shortRangeEarthPrefab, transform.position, transform.rotation) as Rigidbody;
        newSpell.velocity = transform.forward * castSpeed;
        Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), newSpell.GetComponent<Collider>(), true);
        GetComponent<AudioSource>().PlayOneShot(earthSpellLarge);
    }

    public void setFireMage()
    {
        fireMage = true;
        earthMage = false;
        classUI.GetComponent<TMP_Text>().text = "Fire Mage";
        classUI.GetComponent<TMP_Text>().color = Color.red;

    }

    public void setEarthMage()
    {
        earthMage= true;
        fireMage = false;
        classUI.GetComponent<TMP_Text>().text = "Earth Mage";
        classUI.GetComponent<TMP_Text>().color = Color.green;

    }
}
