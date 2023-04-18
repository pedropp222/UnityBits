using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Classe de controlador global, que contem coisas uteis como o jogador e outras informações que são necessárias
/// em vários locais no jogo e que podem ser consultadas usando esta classe. Só pode existir 1 desta classe num nível (vai
/// aparer uma mensagem de erro se existir mais que 1)
/// </summary>
public class UtilsController : MonoBehaviour
{
    public static UtilsController instancia;

    /// <summary>
    /// O prefab da bola azul que tem o TocadorMusica
    /// </summary>
    public GameObject TocadorMusicaPrefab;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Debug.LogError("ATENCAO: Existe mais do que um controlador global (UtilsController). So pode existir 1!");
        }
        
    }
}
