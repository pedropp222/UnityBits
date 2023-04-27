using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Esta classe encarrega-se de carregar ficheiros de audio do disco. A partir de um caminho que fornecemos a esta classe,
/// ela vai validar se se trata de um ficheiro v�lido e carrega ent�o o ficheiro. Caso tudo corra bem, ela chama os eventos
/// (ICarregarEvent) que est�o a escutar este carregador, e este fornece o AudioClip, ou nulo.
/// </summary>

namespace Audio
{
    public class CarregadorAudio
    {
        //O caminho completo do ficheiro a carregar! exemplo: C:/USERS/PEDRO/DESKTOP/PASTA/MUSICA.MP3
        private string caminho = "";

        public void CarregarMusica(string caminho)
        {
            this.caminho = caminho;
            Carregar();
        }

        private void Carregar()
        {
            if (!System.IO.File.Exists(caminho))
            {
                Debug.LogError("ERRO: A LOCALIZACAO: '" + caminho + "' NAO EXISTE");
                OnCarregouAudio?.Invoke(this, null);
                return;
            }

            var tipo = TypeFromExtension();

            Debug.Log("A carregar: " + tipo);

            if (tipo == AudioType.UNKNOWN)
            {
                Debug.LogError("ERRO. O TIPO DE FICHEIRO E DESCONHECIDO. TEM QUE SER UM FICHEIRO DE AUDIO (MP3, WAV, OGG)");
                OnCarregouAudio?.Invoke(this, null);
                return;
            }

            var req = UnityWebRequestMultimedia.GetAudioClip("file://" + caminho, tipo);

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
                        OnCarregouAudio?.Invoke(this, clip);
                    }
                    else
                    {
                        Debug.LogWarning("NAO CARREGOU AUDIO");
                        OnCarregouAudio?.Invoke(this, null);
                    }
                }
            };
        }

        public EventHandler<AudioClip> OnCarregouAudio;

        /// <summary>
        /// Obter o formato atraves do nome completo do ficheiro.
        /// Apenas suporta mp3, wav e ogg, e ja chega muito bem.
        /// </summary>
        /// <returns>O tipo de audio que encontrou, ou entao "unknown"</returns>
        private AudioType TypeFromExtension()
        {
            if (caminho.IndexOf('.') != -1)
            {
                string ext = caminho.Split('.')[^1];

                switch (ext)
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
}