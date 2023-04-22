﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Classe para mover uma parte do corpo de um artista, baseado no som que o instrumento
/// esta a fazer no momento. Esta classe é baseada numa implementação que ja foi feita ha
/// bastante tempo, com algumas pequenas alterações para ficar melhor apresentável, mas
/// vai necessitar de uma revisão para melhor a qualidade.
/// </summary>
[RequireComponent(typeof(Instrumento))]
public class MovimentoSom : MonoBehaviour
{
    public Transform parte;
    [Range(0f, 10f)]
    public float intensidade;
    [Range(0f,1f)]
    public float suavidade;

    private AudioSource audioS;

    float rotacaoInicial;
    float rotAtual;
    float[] espectro;

    /// <summary>
    /// Este script requer o audio source do instrumento para funcionar
    /// </summary>
    private void Start()
    {
        rotacaoInicial = parte.localEulerAngles.x;
        rotAtual = rotacaoInicial;

        espectro = new float[256];
    }

    //Apenas o Instrumento vai chamar este metodo, quando o carregador finalmente carrega um som.
    public void SetAudioSource(AudioSource audio)
    {
        audioS = audio;
    }

    private void Update()
    {
        if (audioS == null || parte == null) return;

        float media = 0f;

        audioS.GetOutputData(espectro, 0);

        for(int i = 0; i < espectro.Length; i++)
        {
            media += espectro[i] * intensidade;
        }

        if (media < 0f) media *= -1f;

        rotAtual = Mathf.Lerp(rotAtual, rotacaoInicial + media, 1f-suavidade);

        Vector3 novaRot = new Vector3(rotAtual, parte.localEulerAngles.y, parte.localEulerAngles.z);

        parte.localEulerAngles = novaRot;        
    }

}
