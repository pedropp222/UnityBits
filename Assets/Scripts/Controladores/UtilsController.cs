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
namespace Controladores
{
    public class UtilsController : MonoBehaviour
    {
        public static UtilsController instancia;

        /// <summary>
        /// O prefab da bola azul que tem o TocadorMusica
        /// </summary>
        public GameObject TocadorMusicaPrefab;

        /// <summary>
        /// Prefab de um artista vazio pronto a ser instanciado para um projeto
        /// </summary>
        public GameObject artistaPrefab;

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

        /// <summary>
        /// Método recursivo para encontrar um objeto pelo seu nome, a partir de um Transform inicial
        /// Claro que só pode haver 1 objeto com o nome que queres, senão pode não encontrar o que querias.
        /// </summary>
        /// <param name="inicio">O transform de onde vai iniciar a procura</param>
        /// <param name="nome">O nome do objeto a encontrar</param>
        /// <returns>O primeiro objeto que encontrou com esse nome ou entao Null se não encontrou nada</returns>
        public GameObject EncontrarObjetoChild(Transform inicio, string nome)
        {
            for (int i = 0; i < inicio.childCount; i++)
            {
                if (inicio.GetChild(i).name == nome)
                {
                    return inicio.GetChild(i).gameObject;
                }
                if (inicio.GetChild(i).childCount > 0)
                {
                    GameObject obj = EncontrarObjetoChild(inicio.GetChild(i), nome);

                    if (obj != null)
                    {
                        return obj;
                    }
                }
            }

            return null;
        }
    }
}