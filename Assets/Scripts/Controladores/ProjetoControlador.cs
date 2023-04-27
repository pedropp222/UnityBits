using System.Collections;
using System.IO;
using Audio;
using UnityEngine;

/// <summary>
/// Classe controlador de projetos, identifica e gere o projeto atual
/// </summary>
namespace Controladores
{
    public class ProjetoControlador : MonoBehaviour
    {
        public static ProjetoControlador instancia;

        private MusicaProjeto projetoAtual;

        private void Awake()
        {
            instancia = this;
            if (!Directory.Exists("projetos"))
            {
                Directory.CreateDirectory("projetos");
            }
        }

        public string GetProjetoNome()
        {
            return projetoAtual != null ? projetoAtual.projetoNome : null;
        }

        public bool ExisteProjeto()
        {
            return projetoAtual != null;
        }

        public void CriarProjeto(string nome)
        {
            if (projetoAtual != null)
            {
                UnityEngine.Debug.LogWarning("Ja esta um projeto carregado");
                return;
            }

            if (Directory.Exists("projetos/" + nome))
            {
                UnityEngine.Debug.LogWarning("Nao deu para criar um projeto com nome " + nome + " porque ja existe");
                return;
            }

            Directory.CreateDirectory("projetos/" + nome);

            projetoAtual = gameObject.AddComponent<MusicaProjeto>();
            projetoAtual.projetoNome = nome;
        }

        public void AdicionarArtista(Artista artista)
        {
            if (projetoAtual == null)
            {
                UnityEngine.Debug.LogWarning("Nao conseguiu adicionar artista porque nao existe nenhum projeto");
                return;
            }

            projetoAtual.AdicionarArtista(artista);
        }
    }
}