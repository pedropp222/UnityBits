using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Debugs
{
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

        public void OnInteragir(RatoBotao botao)
        {
            Debug.Log("INTERAGIR COM BOTAO " + botao);
        }
    }
}