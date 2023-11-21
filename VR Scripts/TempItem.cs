using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempItem : MonoBehaviour
{
    public Transform heldPos;
    public bool grabbed;
    public GameObject blood;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {
            transform.position = heldPos.position;
            transform.rotation = Quaternion.Euler(0, heldPos.parent.transform.eulerAngles.y,0);
        }

    }

    public void grab()
    {
        if (tag == "Head")
        {
            GetComponentInParent<Room2Controller>().FoundHead();
            Instantiate(blood, heldPos);
            Destroy(this.gameObject);
        }

        else
        {
            grabbed = true;
            Destroy(this.gameObject, 2);

            if (tag == "Fish")
            {
                GetComponentInParent<Room2Controller>().FoundFish();
            }
            if (tag == "Gun")
            {
                GetComponentInParent<Room2Controller>().FoundGun();
            }
        }
    }


}
