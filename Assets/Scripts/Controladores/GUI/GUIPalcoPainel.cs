using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIPalcoPainel : MonoBehaviour
{
    private static GameObject palcoPainel;

    private static Text projetoTexto;
    private static Transform painelTransform;
    private static GameObject botaoGenerico;

    public static void Abrir()
    {
        if (palcoPainel == null)
        {
            palcoPainel = GUIControlador.instancia.palcoPainel;
            if (palcoPainel == null)
            {
                Debug.LogError("ERRO: Nao da para abrir o painel do palco, porque nao esta definido no GUIControlador");
                return;
            }
            projetoTexto = palcoPainel.transform.GetChild(1).GetComponent<Text>();
            painelTransform = palcoPainel.transform.GetChild(3);
            botaoGenerico = GUIControlador.instancia.botaoGenerico;
        }

        palcoPainel.SetActive(true);
        InserirOpcoes();
    }

    private static void InserirOpcoes()
    {

    }

    public static void Fechar()
    {
        palcoPainel.SetActive(false);
    }
}
