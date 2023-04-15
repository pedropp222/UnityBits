using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe que permite chamar o controlador de pausa e alterar o estado do jogo, sem clicar no botao de pausa.
/// E obrigatorio colocar este componente num botao.
/// </summary>
[RequireComponent(typeof (Button))]
public class OnClick_TriggerPause : MonoBehaviour
{
    private PausaControlador controlador;

    private void Start()
    {
        //Tentar encontrar o PausaControlador (tem que existir no nosso scene)
        controlador = FindObjectOfType<PausaControlador>();

        if (controlador == null)
        {
            Debug.LogWarning("Controlador de pausa nao existe");
            return;
        }

        //Quando clicar neste botao, fazer toggle da pausa.
        GetComponent<Button>().onClick.AddListener(() => controlador.TogglePause());
    }
}
