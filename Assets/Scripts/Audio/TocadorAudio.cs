using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TocadorAudio : MonoBehaviour, ICarregarEvent, IInteragivel
{
    [SerializeField]
    private string caminhoAtual;

    [Range(0f, 1f)]
    public float volumeAudio;

    private AudioClip audioClip;
    private AudioSource audioSource;

    private CarregadorAudio carregador;

    private void Start()
    {
        carregador = new CarregadorAudio();
        carregador.carregarEvents.Add(this);
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

    private void ApagarTudo()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }

        Destroy(audioSource);
        Destroy(audioClip);

        Debug.Log("Apagou dados deste tocador");
    }

    public void OnInteragir(RatoBotao botao)
    {
        if (botao == RatoBotao.DIREITO)
        {
            ApagarTudo();
            return;
        }

        if (audioClip == null)
        {
            Debug.LogWarning("Nao tem audio para tocar");
            return;
        }

        if (audioSource.isPlaying)
        {
            Debug.Log("Parar audio");
            audioSource.Stop();
        }
        else
        {
            Debug.Log("Iniciar audio");
            audioSource.Play();
        }

    }
}