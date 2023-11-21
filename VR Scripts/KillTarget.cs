using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using TMPro;
public class KillTarget : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f; public int score;
    private float countDown;
    public TMP_Text scoreText;
    void Start()
    {

        score = 0;
        scoreText.text = "Score: 0";
        countDown = timeToSelect;
    }
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation *
        Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject
        == target))
        {
            if (countDown > 0.0f)
            {
                // on target
                countDown -= Time.deltaTime;
                // print (countDown);
                hitEffect.transform.position = hit.point;
                hitEffect.Play();
            }
            else
            {
                // killed
                Instantiate(killEffect, target.transform.position,
                target.transform.rotation);
                score += 1; 
                scoreText.text = "Score: " + score;
                countDown = timeToSelect;
                SetRandomPosition();
            }
        }
        else
        {
            // reset
            countDown = timeToSelect;
            hitEffect.Stop();
        }
    }
    void SetRandomPosition()
    {
        float x = UnityEngine.Random.Range(-5.0f, -50.0f);
        float z = UnityEngine.Random.Range(-5.0f, -50.0f);
        target.transform.position = new Vector3(x, 0.0f, z);
    }
}
