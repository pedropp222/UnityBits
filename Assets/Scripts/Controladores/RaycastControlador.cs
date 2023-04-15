using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que permite a interacao do jogador com os objetos do mundo, usando a camara/rato como apontador
/// </summary>
public class RaycastControlador : MonoBehaviour
{
    [Tooltip("Distancia maxima que se pode interagir com objetos")]
    public float distanciaMaxima;

    public Camera camara;

    private RaycastHit hit;

    private GameObject focusObject = null;

    private void FixedUpdate()
    {
        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, distanciaMaxima))
        {
            if (focusObject != hit.collider.gameObject)
            {
                if (focusObject != null)
                {
                    CallHoverEnd();
                }

                focusObject = hit.collider.gameObject;
                CallHoverStart();
            }
        }
        else
        {
            if (focusObject != null)
            {
                CallHoverEnd();
                focusObject = null;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && focusObject != null)
        {
            foreach (IInteragivel interagivel in focusObject.GetComponents<IInteragivel>())
            {
                interagivel.OnInteragir();
            }
        }
    }

    private void CallHoverStart()
    {
        foreach (IHoverable hoverable in focusObject.GetComponents<IHoverable>())
        {
            hoverable.OnHoverStart();
        }
    }

    private void CallHoverEnd()
    {
        foreach (IHoverable hoverable in focusObject.GetComponents<IHoverable>())
        {
            hoverable.OnHoverEnd();
        }
    }

}
