using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamMatching : MonoBehaviour
{

    public Transform playerCamera;
    public Transform portal;
    public Transform portalExit;
    public bool reverse;

    // Update is called once per frame
    void Update()
    {
      
            // Pairs portal camera with player camera

        Vector3 playerRelativeToPortal = playerCamera.position - portal.position;
        if (reverse)
        {
            transform.position = portalExit.position - playerRelativeToPortal;
        }
        else
        {
            transform.position = portalExit.position + playerRelativeToPortal;
        }

            // Matches camera and player rotation

        float portalDifferences = Quaternion.Angle(portal.rotation, portalExit.rotation);

        Quaternion portalRotDifference = Quaternion.AngleAxis(portalDifferences, Vector3.up);
        Vector3 updateCamDir = portalRotDifference * playerCamera.forward;
        
        transform.rotation = Quaternion.LookRotation(updateCamDir, Vector3.up);
        

        
    }
}
