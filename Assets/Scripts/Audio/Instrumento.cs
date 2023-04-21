using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// O instrumento é onde ficam guardadas as informações de quais sons este artista vai tocar.
/// Cada instrumento tem guardada o seu TocadorAudio que é a classe que irá carregar e tocar o som.
/// Contém também uma classe MovimentoSom, que escuta o TocadorAudio e que faz o artista mecher uma
/// parte do corpo ao mesmo tempo que o audio deste TocadorAudio muda.
/// </summary>
public class Instrumento : MonoBehaviour
{
    private TocadorAudio tocador;

    public MovimentoSom movimento;

    private void Start()
    {
        tocador = gameObject.AddComponent<TocadorAudio>();
    }

    //Começar a tocar o som deste instrumento, e dar ao MovimentoSom o AudioSource que precisa para fazer o seu movimento
    public void Tocar()
    {
        if (tocador.ProntoATocar())
        {
            movimento.SetAudioSource(tocador.audioSource);
            tocador.Tocar();
        }
    }
}

