using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float removeTime = 3.0f;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, removeTime);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        
            Instantiate(explosion, transform.position, transform.rotation);
        
        Destroy(gameObject);
    }
}
