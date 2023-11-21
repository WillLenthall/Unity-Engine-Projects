using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public Transform heldPos;
    public Transform originalPos;
    public bool grabbed;
    public bool triggered = false;
    public Animator anim;
    public bool isStraight;
    public bool needTool = false;
    // Start is called before the first frame update
    void Start()
    {
        isStraight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {
            transform.position = heldPos.position;
            transform.rotation = Quaternion.Euler(90, heldPos.parent.transform.eulerAngles.y - 180, transform.eulerAngles.z);


            if (!triggered && heldPos.parent.transform.eulerAngles.z > 45 && heldPos.parent.transform.eulerAngles.z < 86 && tag == "Spoon")
            {
                bendSpoon();
            }

            if (triggered && heldPos.parent.transform.eulerAngles.z > 274 && heldPos.parent.transform.eulerAngles.z < 316 && tag == "Spoon" && !isStraight)
            {
                bendBack();
            }
        }

    }

    public void setGrabbed()
    {

        if (grabbed) 
        { 
            transform.position = originalPos.position;
            if (triggered)
            {
                transform.rotation = Quaternion.Euler(originalPos.eulerAngles.x, originalPos.eulerAngles.y, 60);
            }
            else
            {
                transform.rotation = originalPos.rotation;
            }
        }
        if (!needTool || (needTool && !grabbed))
        {
            grabbed = !grabbed;
        }

    }

    public void bendSpoon()
    {
        anim.SetBool("BendSpoon", true);
        triggered = true;
        isStraight = false;
        GetComponent<AudioSource>().Play();
        Invoke("Progress", 3f);
        Invoke("StopSound", 3f);
    }
    void Progress()
    {
        GetComponentInParent<UIController>().completedText();
    }

    void StopSound()
    {
        GetComponent<AudioSource>().Stop();
    }
    public void bendBack()
    {
        anim.SetBool("BendSpoon", false);
        anim.SetBool("BendBack", true);
        isStraight = true;
        GetComponent<AudioSource>().time = 0.5f;
        GetComponent<AudioSource>().Play();
        Invoke("StopSound", 2f);
    }

    public bool GetGrabbed()
    {
        return grabbed;
    }

    public bool SpoonStraight()
    {
        return isStraight;
    }

    public void NeedAsTool()
    {
        if (!needTool)
        {
            needTool = true;
            Vector3 temp = new Vector3(0, 0.2f, 0);
            heldPos.position = heldPos.position - temp;
        }
    }

    public void DontNeedAsTool()
    {
        if (needTool)
        {
            needTool = false;
            Vector3 temp = new Vector3(0, 0.2f, 0);
            heldPos.position = heldPos.position + temp;
        }
    }
}
