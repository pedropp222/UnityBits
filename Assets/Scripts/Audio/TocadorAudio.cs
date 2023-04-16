using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TocadorAudio : MonoBehaviour, ICarregarEvent, IInteragivel
{
    [SerializeField]
    private List<string> listaFicheiros;

    [Range(0f, 1f)]
    public float volumeAudio;

    private List<AudioClip> audioClips;
    private List<AudioSource> audioSources;

    private CarregadorAudio carregador;

    private void Start()
    {
        audioClips = new List<AudioClip>();
        audioSources = new List<AudioSource>();

        carregador = new CarregadorAudio();
        carregador.carregarEvents.Add(this);
    }

    public void AdicionarMusica(string caminho)
    {
        listaFicheiros.Add(caminho);
        CarregarClips();
    }

    private void CarregarClips()
    {
        if (audioClips.Count == listaFicheiros.Count)
        {
            return;
        }

        carregador.CarregarMusica(listaFicheiros[audioClips.Count]);
    }

    public void OnCarregouAudio(AudioClip clip, string cam)
    {
        if (clip == null)
        {
            listaFicheiros.Remove(cam);
        }
        else
        {
            audioClips.Add(clip);
            CriarAudioSource(clip);
        }
        CarregarClips();
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
        
        audioSources.Add(asource);
    }

    private void ApagarTudo()
    {
        for(int i = 0; i < audioSources.Count; i++)
        {
            Destroy(audioSources[i].gameObject);
        }
        audioSources.Clear();

        for (int i = 0; i < audioClips.Count; i++)
        {
            Destroy(audioClips[i]);
        }
        audioClips.Clear();

        listaFicheiros.Clear();

        Debug.Log("Apagou todas as musicas");
    }

    public void OnInteragir(RatoBotao botao)
    {
        if (botao == RatoBotao.DIREITO)
        {
            ApagarTudo();
            return;
        }

        if (audioClips.Count == 0)
        {
            Debug.LogWarning("Nao ha clips para tocar");
            return;
        }

        foreach (AudioSource s in audioSources)
        {
            if (s.isPlaying)
            {
                Debug.Log("Parar audios");
                s.Stop();
            }
            else
            {
                Debug.Log("Iniciar audios");
                s.Play();
            }
        }
    }
}