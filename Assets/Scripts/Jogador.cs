using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
/// Classe muito simples que so tem algumas coisas basicas sobre o jogador. So tem o componente IPausable para
/// ativar / desativar o jogador e o rato quando colocamos em pausa ou quando continuamos o jogo.
/// </summary>
public class Jogador : MonoBehaviour, IPausable
{
    private MouseLook rato;
    public FirstPersonController fps;

    void Awake()
    {
        rato = fps.m_MouseLook;
    }

    //Ativar / desativar o jogador e o rato
    public void SetMover(bool estado)
    {
        rato.SetCursorLock(estado);
        fps.SetMoving(estado);
        fps.SetRotate(estado);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (!Cursor.visible)
            {
                SetMover(false);
            }
        }
        else if (!Input.GetKey(KeyCode.Tab))
        {
            if (Cursor.visible)
            {
                SetMover(true);
            }
        }
    }

    //Chamado automaticamente pelo PausaControlador
    public void OnPause(bool state)
    {
        SetMover(!state);
    }
}
