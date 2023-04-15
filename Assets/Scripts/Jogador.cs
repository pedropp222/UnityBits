using System.Collections;
using System.Collections.Generic;
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

    void Start()
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

    //Chamado automaticamente pelo PausaControlador
    public void OnPause(bool state)
    {
        SetMover(!state);
    }
}
