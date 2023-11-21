using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerDestroy : MonoBehaviour
{
    public float removeTime = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, removeTime);

    }

   
}
