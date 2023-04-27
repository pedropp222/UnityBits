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
namespace Audio
{
    public class Instrumento : MonoBehaviour
    {
        [SerializeField]
        private bool ativado;

        public string nomeInstrumento;

        private TocadorAudio tocador;

        public MovimentoSom movimento;

        private void Start()
        {
            tocador = gameObject.AddComponent<TocadorAudio>();
        }

        /// <summary>
        /// Começar a tocar o som deste instrumento, e dar ao MovimentoSom o AudioSource que precisa para fazer o seu movimento
        /// So vai comecar a tocar se este instrumento estiver ativado (vai dar para ativar / desativar sons quando quiseres)
        /// </summary>
        public void Tocar()
        {
            if (tocador.ProntoATocar() && ativado)
            {
                movimento.SetAudioSource(tocador.audioSource);
                tocador.Tocar();
            }
        }

        public bool ProntoATocar()
        {
            return tocador.ProntoATocar();
        }

        public void Ativar()
        {
            ativado = true;
        }

        public void Desativar()
        {
            ativado = false;
        }
    }
}