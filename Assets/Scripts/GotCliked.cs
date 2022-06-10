using UnityEngine;
using UnityEngine.UI;

public class GotCliked : MonoBehaviour
{
    public GameObject originalObject;
    public Toggle objectiveToggle;

    private string _cloneName;

    void Start()
    {
        _cloneName = originalObject.name + " (1)";
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Clone" && hit.transform.name == _cloneName)
            {
                gameObject.SetActive(false);
                originalObject.SetActive(true);
                objectiveToggle.isOn = true;
            }
        }
    }
}
