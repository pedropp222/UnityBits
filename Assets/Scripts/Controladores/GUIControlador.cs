using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Controladores
{
    public class GUIControlador : MonoBehaviour
    {
        /// <summary>
        /// Janela do UI onde pede para introduzir um texto e um botao para confirmar
        /// </summary>
        public GameObject janelaModalTexto;
        /// <summary>
        /// O painel que aparece quando se vai para cima do palco
        /// </summary>
        public GameObject palcoPainel;

        public GameObject botaoGenerico;

        public static GUIControlador instancia;

        private void Awake()
        {
            instancia = this;
        }
    }
}