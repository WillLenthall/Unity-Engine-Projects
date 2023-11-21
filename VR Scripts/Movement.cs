using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject target;
    public bool navSet = true;
    public bool movementEnabled = false;
    public GameObject menu;
    public bool menuActive = false;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (movementEnabled)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (navSet)
                {
                    //UnityEngine.Debug.Log("stop");
                    navSet = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(target.transform.position);
                    GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0;
                }

                else if (!navSet)
                {


                    navSet = true;
                    UnityEngine.Debug.Log("stop");
                    GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 3;

                }

            }

            if (Input.GetKeyDown("space"))
            {
                navSet = true;
                GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 0;
                transform.position = target.transform.position;

            }
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuActive)
            {
                menuActive = true;
                menu.SetActive(true);
                movementEnabled = false;
            }
            else if (menuActive)
            {
                menuActive = false;
                menu.SetActive(false);
                movementEnabled = true;
            }
        }
    }

    public void EnableMovement()
    {
        movementEnabled = true;
    }

    public void ToggleMenuBool()
    {
        menuActive = !menuActive;
    }
}
