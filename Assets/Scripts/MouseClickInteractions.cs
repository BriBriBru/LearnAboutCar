using UnityEngine;

public class MouseClickInteractions : MonoBehaviour
{
    public Animator animator;

    private GameObject descriptionPanel;
    private GameObject shootingSight;

    private bool etatF = true;
    private bool etatO = false;

    void Start()
    {
        descriptionPanel = GameObject.Find("DescriptionPanel");
        descriptionPanel.SetActive(false);
        shootingSight = GameObject.Find("ShootingSight");
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Hood")
                {
                    ManageHoodAnimation();
                }

                if (hit.collider.gameObject.tag == "Car Part")
                {
                    // Disable the shooting sight
                    if (shootingSight.activeSelf)
                    {
                        descriptionPanel.SetActive(true);
                        shootingSight.SetActive(false);
                    }
                }
            }
        }

        // Disable the description panel
        if (Input.GetMouseButtonDown(1))
        {
            descriptionPanel.SetActive(false);
            shootingSight.SetActive(true);
        }
    }

    public void ManageHoodAnimation()
    {
        if (etatF)
        {
            animator.Play("Open Car Hood");
            etatF = false;
            etatO = true;
        }

        else if (etatO)
        {
            animator.Play("Close Car Hood");
            etatF = true;
            etatO = false;
        }
    }
}
