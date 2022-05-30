using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnMe : MonoBehaviour
{

    public string description;
    public Text descriptionText;

    void OnMouseDown()
    {
        // Debug.Log("description de ce gameObject" + this.gameObject.name + ": " + description);
        descriptionText.text = description;
    }
}
