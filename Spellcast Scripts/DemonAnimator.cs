using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAnimator : MonoBehaviour
{

    Animator animator;
    PlayerCombat combatSript;
    EnemyMovement moveScript;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        combatSript = GetComponent<PlayerCombat>();
        moveScript = GetComponent<EnemyMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!combatSript.isAlive())
        {
            animator.SetBool("dead", true);
        }

        if (moveScript.distance()>4)
        {
            animator.SetBool("isRunning", true);
        }
        if (moveScript.distance() < 4)
        {
            animator.SetBool("isRunning", false);
        }


    }
}
