using Audio;
using Controladores;
using Interfaces;
using UnityEngine;

namespace Eventos
{
    [RequireComponent(typeof(Artista))]
    public class OnClick_AdicionarArtista : MonoBehaviour, IInteragivel
    {
        public void OnInteragir(RatoBotao botao)
        {
            if (botao == RatoBotao.ESQUERDO)
            {
                ProjetoControlador.instancia.AdicionarArtista(GetComponent<Artista>());
                Destroy(this);
            }
        }
    }
}