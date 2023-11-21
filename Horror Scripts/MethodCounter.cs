using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodCounter : MonoBehaviour
{
    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FinalCount()
    {
        Debug.Log(counter);
    }
    void CounterIncrease()
    {
        counter++;
    }
}
