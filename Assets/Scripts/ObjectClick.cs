using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public float force = 5f;
    public Animator animator;

    private bool etatF = true;
    private bool etatO = false;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var rig = selection.GetComponent<Rigidbody>();

            if (hit.collider.gameObject.name == "Hood")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Manage();
                }
            }
        }
    }

    public void Manage()
    {
        if (etatF)
        {
            animator.Play("HoodOpen");
            etatF = false;
            etatO = true;
        }

        else if (etatO)
        {
            animator.Play("HoodClose");
            etatF = true;
            etatO = false;
        }
    }
}
