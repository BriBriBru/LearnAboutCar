using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnMe : MonoBehaviour
{

    public string description;
    public Text descriptionText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Debug.Log("description de ce gameObject" + this.gameObject.name + ": " + description);
        descriptionText.text = "Description: " + description;
    }
}
