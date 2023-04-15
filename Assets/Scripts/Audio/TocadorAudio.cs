using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TocadorAudio : MonoBehaviour, ICarregarEvent, IInteragivel
{
    public List<string> listaFicheiros;

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

    public void OnInteragir()
    {
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