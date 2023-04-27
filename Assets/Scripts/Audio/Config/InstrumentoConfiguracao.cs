using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// O componente onde guarda varias informações sobre um instrumento, tal como a parte do corpo que afeta
/// o movimento do som ou mais coisas como transformações dos ossos do artista, ou instanciacao de novos objetos
/// </summary>
namespace Audio.Config
{
    [CreateAssetMenu(fileName = "Dados", menuName = "ScriptableObjects/Instrumento Configuracao", order = 1)]
    public class InstrumentoConfiguracao : ScriptableObject
    {
        public string parteCorpo;

        [Range(0f, 1f)]
        public float volumeAudio;

        [Range(0f, 10f)]
        public float intensidadeMovimento;
        [Range(0f, 1f)]
        public float suavidadeMovimento;

        [SerializeField]
        public List<OssosTransformacaoConfiguracao> transformacoesOssos;

        [SerializeField]
        public List<InstanciarConfiguracao> configuracoesInstanciacao;
    }

    /// <summary>
    /// Classe para configurar um novo objeto que vai ser instanciado quando o jogo iniciar
    /// Este objeto pode ser criado dentro de uma parte do corpo do artista (nomeParente), ou entao no mundo em si (nao se
    /// coloca nada no nomeParente).
    /// Tambem da para definir uma posicao ou rotacao local a aplicar no objeto instanciado.
    /// </summary>
    [System.Serializable]
    public class InstanciarConfiguracao
    {
        public GameObject objeto;
        public string nomeParente;
        public Vector3 posicaoLocal;
        public Vector3 rotacaoLocal;
    }


    /// <summary>
    /// Classe onde de pode definir uma transformacao a acontecer ao osso de um artista.
    /// O nomeParte é o nome da parte do corpo que vai ser afetada. rotacaoLocal é a rotaçao que vai ser aplicada a esta
    /// parte do corpo.
    /// </summary>
    [System.Serializable]
    public class OssosTransformacaoConfiguracao
    {
        public string nomeParte;
        public Vector3 rotacaoLocal;
    }
}