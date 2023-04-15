using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDebug : MonoBehaviour, IHoverable, IInteragivel
{

    public Material normalMaterial;

    public Material hoverMaterial;


    public void OnHoverEnd()
    {
        Debug.Log("HOVER END");
        GetComponent<Renderer>().material = normalMaterial;
    }

    public void OnHoverStart()
    {
        Debug.Log("HOVER START");
        GetComponent<Renderer>().material = hoverMaterial;
    }

    public void OnInteragir()
    {
        Debug.Log("INTERAGIR");
    }
}
