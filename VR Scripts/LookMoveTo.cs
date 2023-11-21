using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using TMPro;
public class LookMoveTo : MonoBehaviour
{
    public GameObject ground;
    public GameObject ground1;
    public GameObject ground2;
    private TMP_Text infoText;
    void Start()
    {
    
    }
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;
        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;
            if (hitObject == ground || ground1 || ground2)
            {
                
                transform.position = hit.point;
            }
        }
    }
}
