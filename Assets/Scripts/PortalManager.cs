using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{

    public GameObject MainCamera;

    public GameObject Photo;

    private Material[] PhotoMaterials;

    private Material PortalPlaneMaterial;

      void Update()
    {

        PhotoMaterials = Photo.GetComponent<Renderer>().sharedMaterials;
        PortalPlaneMaterial = GetComponent<Renderer>().sharedMaterial;
        
    }  
    
    // Update is called once per frame
    void OnTriggerStay(Collider collider)
    {
        Vector3 camPositionInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position);

        if(camPositionInPortalSpace.y <= 0.0f)
        {
            for(int i = 0; i < PhotoMaterials.Length; ++i)
            {
                PhotoMaterials[i].SetInt("_StencilComp", (int)CompareFunction.NotEqual); 
            }

            PortalPlaneMaterial.SetInt("_CullMode", (int)CullMode.Front);
        }
        
        
        else if (camPositionInPortalSpace.y < 0.3f) //0.5
        {
            //disable stencil test
            for(int i = 0; i < PhotoMaterials.Length; ++i)
            {
                PhotoMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always); 
            }

            PortalPlaneMaterial.SetInt("_CullMode", (int)CullMode.Off);
        }
        else
        {
            //enable stencil test
            for(int i = 0; i < PhotoMaterials.Length; ++i)
            {
                PhotoMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal); 
            }

            PortalPlaneMaterial.SetInt("_CullMode", (int)CullMode.Back);
        }
    }
}
