﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Audio
{
    public class TocadorAudio : MonoBehaviour
    {
        [SerializeField]
        private string caminhoAtual;

        [Range(0f, 1f)]
        public float volumeAudio;

        private AudioClip audioClip;
        public AudioSource audioSource { get; private set; }

        private CarregadorAudio carregador;

        private void Start()
        {
            carregador = new CarregadorAudio();
            carregador.OnCarregouAudio += (sender, clip) => OnCarregouAudio(clip);
        }

        public void AdicionarMusica(string caminho)
        {
            if (caminhoAtual.Length == 0 || audioClip == null)
            {
                caminhoAtual = caminho;
                carregador.CarregarMusica(caminhoAtual);
            }
            else
            {
                Debug.LogWarning("Este tocador ja tem uma musica adicionada.");
            }
        }

        public void OnCarregouAudio(AudioClip clip)
        {
            if (clip != null)
            {
                audioClip = clip;
                CriarAudioSource(clip);
            }
        }

        private void CriarAudioSource(AudioClip clip)
        {
            AudioSource asource = gameObject.AddComponent<AudioSource>();
            asource.clip = clip;
            asource.dopplerLevel = 0.5f;
            asource.minDistance = 10f;
            asource.maxDistance = 110f;
            asource.spatialBlend = 1.0f;
            asource.volume = volumeAudio;
            asource.playOnAwake = false;

            asource.SetCustomCurve(AudioSourceCurveType.Spread, AnimationCurve.Constant(0f, 1f, 0.2f));

            audioSource = asource;
        }

        public void ApagarTudo()
        {
            if (audioSource != null)
            {
                audioSource.Stop();
            }

            Destroy(audioSource);
            Destroy(audioClip);

            Debug.Log("Apagou dados deste tocador");
        }

        /// <summary>
        /// Verificar se este tocador ta pronto a ser tocado ou se ainda nao tem nenhum clip
        /// </summary>
        /// <returns>Se ta pronto a tocar!</returns>
        public bool ProntoATocar()
        {
            return audioSource != null;
        }

        public void Tocar()
        {
            if (ProntoATocar())
            {
                audioSource.Play();
            }
        }

        public void Parar()
        {
            if (ProntoATocar())
            {
                audioSource.Stop();
            }
        }
    }
}