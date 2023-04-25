using System.Collections;
using UnityEngine;

public class ProjetoControlador : MonoBehaviour
{
    public static ProjetoControlador instancia;

    private MusicaProjeto projetoAtual;

    private void Awake()
    {
        instancia = this;
    }

    public bool ExisteProjeto()
    {
        return projetoAtual != null;
    }

    public void CriarProjeto(string nome)
    {
        if (projetoAtual == null)
        {
            Debug.LogWarning("Ja esta um projeto carregado");
            return;
        }

        projetoAtual = gameObject.AddComponent<MusicaProjeto>();
        projetoAtual.projetoNome = nome;
    }

    public void AdicionarArtista(Artista artista)
    {
        if (projetoAtual == null)
        {
            Debug.LogWarning("Nao conseguiu adicionar artista porque nao existe nenhum projeto");
            return;
        }

        projetoAtual.AdicionarArtista(artista);
    }
}