using Audio.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Classe de utilidades em que escreve a listagem de transformacoes dos ossos que foram feitas
/// Qualquer osso que tenha sido modificado no editor vai aparecer na listagem e depois disso so necessita
/// de colar isso numa configuracao
/// </summary>
namespace Audio.Utils
{
    public class PoseEscritor : MonoBehaviour
    {
        public List<OssosTransformacaoConfiguracao> ossosTransformacoes = new List<OssosTransformacaoConfiguracao>();

        [ExecuteInEditMode]
        public void EscreverOssos(Transform inicio)
        {
            if (inicio == null)
            {
                inicio = transform;
            }

            for (int i = 0; i < inicio.childCount; i++)
            {
                if (inicio.GetChild(i).transform.localEulerAngles != Vector3.zero)
                {
                    ossosTransformacoes.Add(new OssosTransformacaoConfiguracao()
                    {
                        nomeParte = inicio.GetChild(i).name,
                        rotacaoLocal = inicio.GetChild(i).transform.localEulerAngles
                    });
                }
                if (inicio.GetChild(i).transform.childCount > 0)
                {
                    EscreverOssos(inicio.GetChild(i).transform);
                }
            }
        }

        [ExecuteInEditMode]
        public void ResetarOssos(Transform inicio)
        {
            if (inicio == null)
            {
                inicio = transform;
            }

            for (int i = 0; i < inicio.childCount; i++)
            {
                inicio.GetChild(i).transform.localEulerAngles = Vector3.zero;
                if (inicio.GetChild(i).transform.childCount > 0)
                {
                    ResetarOssos(inicio.GetChild(i).transform);
                }
            }

            ossosTransformacoes.Clear();
        }
    }
}