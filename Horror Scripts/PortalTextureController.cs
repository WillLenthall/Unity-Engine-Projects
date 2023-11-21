using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureController : MonoBehaviour
{
    public Camera farCam;
    public Material farCamProjection;

    void Start()
    {
        if (farCam.targetTexture != null)
        {
            farCam.targetTexture.Release();
        }
        farCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

    }
    // Update is called once per frame
    void Update()
    {
        farCamProjection.mainTexture = farCam.targetTexture;
    }
}
