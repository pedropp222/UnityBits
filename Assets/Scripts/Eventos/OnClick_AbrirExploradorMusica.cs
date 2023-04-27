using Audio;
using Interfaces;
using UnityEngine;

namespace Eventos
{
    public class OnClick_AbrirExploradorMusica : MonoBehaviour, IInteragivel
    {
        public ExploradorAudio explorador;
        public TocadorAudio tocadorAudio;

        public void OnInteragir(RatoBotao botao)
        {
            if (botao == RatoBotao.ESQUERDO)
            {
                explorador.gameObject.SetActive(true);
                explorador.Mostrar(tocadorAudio);
            }
        }
    }
}