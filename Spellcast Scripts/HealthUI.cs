using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HealthUI : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = "Health: " + player.GetComponent<PlayerCombat>().getHP();
    }
}
