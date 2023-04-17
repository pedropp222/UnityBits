using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Carregar ficheiros de audio a partir de uma localizacao no disco
/// </summary>
public class CarregadorAudio
{
    //O caminho completo do ficheiro a carregar! exemplo: C:/USERS/PEDRO/DESKTOP/PASTA/MUSICA.MP3
    private string caminho = "";

    public List<ICarregarEvent> carregarEvents = new List<ICarregarEvent>();

    public void CarregarMusica(string caminho)
    {
        this.caminho = caminho;
        Carregar();
    }

    private void Carregar()
    {
        if (!System.IO.File.Exists(caminho))
        {
            Debug.LogError("ERRO: A LOCALIZACAO: " + caminho + " NAO EXISTE");
            OnCarregouAudio(null);
            return;
        }

        var tipo = TypeFromExtension();

        Debug.Log("A carregar: "+tipo);

        if (tipo == AudioType.UNKNOWN)
        {
            Debug.LogError("ERRO. O TIPO DE FICHEIRO E DESCONHECIDO. TEM QUE SER UM FICHEIRO DE AUDIO (MP3, WAV, OGG)");
            OnCarregouAudio(null);
            return;
        }

        var req = UnityWebRequestMultimedia.GetAudioClip("file://" + caminho,tipo);

        ((DownloadHandlerAudioClip)req.downloadHandler).streamAudio = true;

        req.SendWebRequest().completed += (x) =>
        {
            DownloadHandlerAudioClip carregador = (DownloadHandlerAudioClip)req.downloadHandler;

            if (carregador.isDone)
            {
                AudioClip clip = carregador.audioClip;

                if (clip != null)
                {
                    Debug.Log("CARREGOU AUDIO");
                    OnCarregouAudio(clip);
                }
                else
                {
                    Debug.LogWarning("NAO CARREGOU AUDIO");
                    OnCarregouAudio(null);
                }
            }
        };      
    }

    private void OnCarregouAudio(AudioClip audio)
    {
        foreach(ICarregarEvent carregarEvent in carregarEvents) 
        {
            carregarEvent.OnCarregouAudio(audio);
        }
    }

    private AudioType TypeFromExtension()
    {
        if (caminho.IndexOf('.')!=-1)
        {
            string ext = caminho.Split('.')[^1];

            switch(ext)
            {
                case "mp3":
                    return AudioType.MPEG;
                case "ogg":
                    return AudioType.OGGVORBIS;
                case "wav":
                    return AudioType.WAV;
                default:
                    return AudioType.UNKNOWN;
            }
        }
        
        return AudioType.UNKNOWN;
    }
}
