using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que ativa / desativa objetos dependendo se o jogo esta em pausa ou nao.
/// </summary>
public class OnPause_ToggleObjects : MonoBehaviour, IPausable
{
    public GameObject[] objects;

    [Tooltip("Se falso, vai desligar os objetos ao fazer pausa, e liga-los ao continuar. Se verdadeiro, faz o inverso.")]
    public bool invert;

    void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(!invert);
        }
    }

    public void OnPause(bool state)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(invert ? state : !state);
        }
    }
}
