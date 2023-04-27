using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eventos
{
    public class OnTrigger_AbrirPalcoGUIPanel : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                
            }
        }
    }
}