using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
}
