using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public class Explose_engine : MonoBehaviour
{
    // Start is called before the first frame update
    //GameObject Transform motor;
    //transform.position += new Vector3(x, y, z);
    public Vector3 newPosition = Vector3.zero;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        newPosition *= Time.deltaTime;
        transform.position += newPosition;
    }



}
