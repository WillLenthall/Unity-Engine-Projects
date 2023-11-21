using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    public GameObject fpChar;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3 (0f,-0.79f,0f);
        //transform.rotation = Quaternion.Euler(0, 15, 0);
        if (Input.GetKey("w"))
        {
            animator.SetBool("isRunning", true);
        }

        if (!Input.GetKey("w"))
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKey("s"))
        {
            animator.SetBool("isRunningBack", true);
        }

        if (!Input.GetKey("s"))
        {
            animator.SetBool("isRunningBack", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Caster script = transform.parent.gameObject.GetComponentInChildren <Caster>();
            if (script.lrCD == 0)
            {
                animator.SetTrigger("cast");
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Caster script = transform.parent.gameObject.GetComponentInChildren<Caster>();
            if (script.srCD == 0)
            {
                animator.SetTrigger("cast");
            }
        }

        if (Input.GetKey("space"))
        {
            animator.SetTrigger("jump");

        }

        if (!fpChar.GetComponent<PlayerCombat>().isAlive())
        {
            animator.SetBool("dead", true);
        }

    }
}
