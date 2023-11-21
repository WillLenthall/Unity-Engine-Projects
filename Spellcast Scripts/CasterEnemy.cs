using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasterEnemy : MonoBehaviour
{
    public Rigidbody longRangeFirePrefab;
    public Rigidbody shortRangeFirePrefab;

    public int lrCD = 0;
    public int srCD = 0;

    public Rigidbody longRangeEarthPrefab;
   public Rigidbody shortRangeEarthPrefab;

    public AudioClip fireSpellLarge;
    public AudioClip earthSpellLarge;

    public float castSpeed = 10.0f;
    private int timer;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();

        InvokeRepeating("CooldownCounter", 1f, 1f);  //1s delay, repeat every 1s

    }

    // Update is called once per frame
    void Update()
    {
        float distance = transform.parent.GetComponent<EnemyMovement>().distance();

        if (transform.parent.GetComponent<PlayerCombat>().isAlive())
        {
            Invoke("incTimer", 1f);

            if (lrCD == 0 && distance > 4)
            {
               spell();
                animator.SetTrigger("cast");


            }
            else if (srCD == 0 && distance <= 4)
            {

               shortSpell();
                animator.SetTrigger("cast");

            }

        }

     }


    


    void CooldownCounter()
    {
        if (lrCD > 0)
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
        if (timer % 2 == 0)
        {
            Rigidbody newSpell = Instantiate(longRangeEarthPrefab, transform.position, transform.rotation) as Rigidbody;
            newSpell.velocity = transform.forward * castSpeed;
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), newSpell.GetComponent<Collider>(), true);
            GetComponent<AudioSource>().PlayOneShot(earthSpellLarge);

            lrCD = 3;
        }

        else
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
        if (timer % 2 == 0)
        {
            srCD = 3;
            smallEarthProjectile();
            Invoke("smallEarthProjectile", 0.3f);
            Invoke("smallEarthProjectile", 0.6f);
            
        }

        else
        {

            Rigidbody newSpell = Instantiate(shortRangeFirePrefab, transform.position, transform.rotation) as Rigidbody;
            newSpell.GetComponent<ParticleSystem>().Play();
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), newSpell.GetComponent<Collider>(), true);
            GetComponent<AudioSource>().PlayOneShot(fireSpellLarge);

            srCD = 3;
        }

    }

    void incTimer()
    {
        timer++;
    }

    void smallEarthProjectile()
    {
        Rigidbody newSpell = Instantiate(shortRangeEarthPrefab, transform.position, transform.rotation) as Rigidbody;
        newSpell.velocity = transform.forward * castSpeed;
        Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), newSpell.GetComponent<Collider>(), true);
        GetComponent<AudioSource>().PlayOneShot(earthSpellLarge);
    }
}
