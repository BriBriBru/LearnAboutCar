using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public Animator animator;

    private bool etatF = true;
    private bool etatO = false;

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
                    ManageAnimation();
                }
            }
        }

    }

    public void ManageAnimation()
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
