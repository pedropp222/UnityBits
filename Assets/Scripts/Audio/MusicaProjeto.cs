using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

///Este é a classe "principal" do grande sistema de projetos de musica. Nesta classe ficam localizados todos os artistas que pertencem
///a este projeto e os seus instrumentos. Contem tambem vários métodos utilitários para fazer uma diversidade de ações que dizem
///respeito a gestao / criaçao de projetos
public class MusicaProjeto : MonoBehaviour
{
    public string projetoNome;

    //A lista de artistas deste projeto
    [SerializeField]
    private List<Artista> listaArtistas;

    //Os instrumentos de todos os artistas, nao so de um
    private List<Instrumento> instrumentoArtistas;

    private void Start()
    {
        listaArtistas = new List<Artista>();
        instrumentoArtistas = new List<Instrumento>();
    }

    public void AdicionarArtista(Artista a)
    {
        listaArtistas.Add(a);

        a.OnCarregouInstrumento += (sender, instrumento) =>
        {
            instrumentoArtistas.Add(instrumento);
        };
    }

    /// <summary>
    /// Verificar se TODOS os instrumentos de todos os artistas tem um som carregado.
    /// </summary>
    public bool TodosInstrumentosProntos()
    {
        foreach(Instrumento instrumento in instrumentoArtistas) 
        { 
            if(!instrumento.ProntoATocar())
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Gravar projeto no disco, na localizacao que ja foi criada
    /// </summary>
    public void GravarProjeto()
    {
        
    }
}
