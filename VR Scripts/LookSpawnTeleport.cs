using UnityEngine;
public class LookSpawnTeleport : MonoBehaviour
{
    private Color saveColor;
    private GameObject currentTarget;
    public GameObject menu;
    public bool menuActive = false;

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;
        GameObject hitTarget;
        ray = new Ray(camera.position, camera.rotation *
        Vector3.forward);
        if (Physics.Raycast(ray, out hit, 10f,
        LayerMask.GetMask("TeleportSpawn")))
        {
            hitTarget = hit.collider.gameObject;
            if (hitTarget != currentTarget)
            {
                Unhighlight();
                Highlight(hitTarget);
            }
            if (Input.GetKeyDown("space"))
            {
                transform.position = new Vector3(hitTarget.transform.position.x,
                1.6f, hitTarget.transform.position.z);
                GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(hitTarget.transform.position);
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(hitTarget.transform.position);
            }
        }
        else if (currentTarget != null)
        {
            Unhighlight();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuActive)
            {
                menuActive = true;
                menu.SetActive(true);
            }
            else if (menuActive)
            {
                menuActive = false;
                menu.SetActive(false);
            }
        }
    }

    private void Highlight(GameObject target)
    {
        Material material = target.GetComponent<Renderer>().material;
        saveColor = material.color;
        Color hiColor = material.color;
        hiColor.a = 0.8f; // more opaque
        material.color = hiColor;
        currentTarget = target;
    }
    private void Unhighlight()
    {
        if (currentTarget != null)
        { 
            Material material =
            currentTarget.GetComponent<Renderer>().material;
            material.color = saveColor;
            currentTarget = null;
        }
    }

    public void ToggleMenuBool()
    {
        menuActive = !menuActive;
    }

}
