using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que ativa / desativa uma lista de componentes dependendo se o jogo esta em pausa ou nao.
/// Os componentes sao desativados / ativados quando se coloca o jogo em pausa. O contrario acontece quando
/// quisermos continuar a jogar.
/// Tambem e possivel inverter as acoes.
/// </summary>
public class OnPause_ToggleComponent : MonoBehaviour, IPausable
{
    //Lista de componentes
    public MonoBehaviour[] componentes;

    [Tooltip("Se falso, vai desligar os componentes ao fazer pausa, e liga-los ao continuar. Se verdadeiro, faz o inverso.")]
    public bool invert;

    void Start()
    {
        for (int i = 0; i < componentes.Length; i++)
        {
            componentes[i].enabled = !invert;
        }
    }

    //Chamado automaticamente pelo PausaControlador
    public void OnPause(bool state)
    {
        for (int i = 0; i < componentes.Length; i++)
        {
            componentes[i].enabled = invert ? state : !state;
        }
    }
}
