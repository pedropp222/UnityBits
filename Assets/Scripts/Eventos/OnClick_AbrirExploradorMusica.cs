using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
