using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

/// <summary>
/// Classe que permite a interacao do jogador com os objetos do mundo, usando a camara/rato como apontador
/// </summary>
namespace Controladores
{
    public class RaycastControlador : MonoBehaviour
    {
        [Tooltip("Distancia maxima que se pode interagir com objetos")]
        public float distanciaMaxima;

        public Camera camara;

        private RaycastHit hit;

        private GameObject focusObject = null;

        public static RaycastControlador instancia;

        private void Awake()
        {
            instancia = this;
        }

        //TODO: Limpar isto, melhorar o sistema de 'colocarObjeto' para dar para rodar um objeto.
        //Isto do colocar objeto tem que sair daqui para fora do RaycastControlador e ir para outro sitio

        private void FixedUpdate()
        {
            if (Cursor.lockState != CursorLockMode.Locked) return;

            if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, distanciaMaxima))
            {
                if (focusObject != hit.collider.gameObject)
                {
                    if (focusObject != null)
                    {
                        ChamarHoverEnd();
                    }

                    focusObject = hit.collider.gameObject;
                    ChamarHoverStart();
                }
            }
            else
            {
                if (focusObject != null)
                {
                    ChamarHoverEnd();
                    focusObject = null;
                }
            }
        }

        void Update()
        {
            if (Cursor.lockState != CursorLockMode.Locked) return;

            bool button0 = Input.GetMouseButtonDown(0);
            bool button1 = Input.GetMouseButtonDown(1);

            if ((button0 || button1) && focusObject != null)
            {
                foreach (IInteragivel interagivel in focusObject.GetComponents<IInteragivel>())
                {
                    interagivel.OnInteragir(button0 ? RatoBotao.ESQUERDO : RatoBotao.DIREITO);
                }
            }
            
        }

        private void ChamarHoverStart()
        {
            foreach (IHoverable hoverable in focusObject.GetComponents<IHoverable>())
            {
                hoverable.OnHoverStart();
            }
        }

        private void ChamarHoverEnd()
        {
            foreach (IHoverable hoverable in focusObject.GetComponents<IHoverable>())
            {
                hoverable.OnHoverEnd();
            }
        }

    }
}