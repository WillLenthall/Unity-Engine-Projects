using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsHider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("hide", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void hide()
    {
        gameObject.SetActive(false);
    }
}
