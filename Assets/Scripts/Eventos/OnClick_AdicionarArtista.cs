using UnityEngine;

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