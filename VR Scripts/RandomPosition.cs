using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;

public class RandomPosition : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RePositionWithDelay());
    }
    IEnumerator RePositionWithDelay()
    {
        while (true)
        {
            SetRandomPosition();
            yield return new WaitForSeconds(5);
        }
    }
    void SetRandomPosition()
    {
        float x = UnityEngine.Random.Range(-4.0f, 13.0f);
        float z = UnityEngine.Random.Range(6.0f, 25f);
        UnityEngine.Debug.Log("X,Z: " + x.ToString("F2") + ", " +
        z.ToString("F2"));
        transform.position = new Vector3(x, 9.70f, z);
    }
}
