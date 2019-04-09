using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{

    public GameObject sphereObject;

    public Dropdown materialDropdown;

    public Material materialOne;

    public Material materialTwo;

    public Material materialThree;

    // void Start()
    // {
    //     sphereObject = GameObject.Find("/Portal/Sphere");
    // }

    // Update is called once per frame
    void Update()
    {
        
        switch(materialDropdown.value)
        {
            case 0:
                sphereObject.GetComponent<Renderer>().material = materialOne;
                break;
            case 1:
                sphereObject.GetComponent<Renderer>().material = materialTwo;
                break;
            case 2:
                sphereObject.GetComponent<Renderer>().material = materialThree;
                break;
        }

    }
}
