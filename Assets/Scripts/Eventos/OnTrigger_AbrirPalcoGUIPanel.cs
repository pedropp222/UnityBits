using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger_AbrirPalcoGUIPanel : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GUIPalcoPainel.Abrir();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GUIPalcoPainel.Fechar();
        }
    }
}
