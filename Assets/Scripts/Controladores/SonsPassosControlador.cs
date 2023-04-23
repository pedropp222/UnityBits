using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Controladores
{
    /// <summary>
    /// Classe que controla os sons dos passos do jogador.
    /// Utiliza um sistema em que usa a tag da superficie para assim tocar um som aleatorio de uma lista.
    /// Essa lista dos tags e dos sons existe num objeto Scriptable Object do tipo SonsPassosDados.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SonsPassosControlador : MonoBehaviour
    {
        
        private AudioSource m_AudioSource;

        private RaycastHit hit;

        [Tooltip("O objeto que contem os dados dos passos nas diferentes superficies")]
        public SonsPassosDados objetoDados;

        [Tooltip("Simulacao de Eco em zonas amplas")]
        public bool simularEco;

        private void Start()
        {
            //buscar o audio source que tem obrigatoriamente que existir
            m_AudioSource = GetComponent<AudioSource>();
        }

        public void ReceberPasso()
        {
            //fazer um raycast para baixo para detetar a superficie
            if (Physics.Raycast(transform.position, -transform.up, out hit, 5f))
            {
                //ver se o material em que esta o jogador contem sons

                Material chao = hit.collider.gameObject.GetComponent<MeshRenderer>()?.sharedMaterials[0];

                if (chao != null)
                {
                    SomDados s = objetoDados.GetSomDados(chao);
                    if (s != null)
                    {

                        if (simularEco)
                        {
                            //simular eco antes de tocar o som
                            AudioMixerGroup audioMixer = m_AudioSource.outputAudioMixerGroup;

                            if (Physics.Raycast(transform.position, transform.up, out hit, 100f))
                            {
                                //dentro de um local qualquer ate 100m
                                float t = Mathf.Clamp01(Vector3.Distance(transform.position, hit.point) / 15f);
                                audioMixer.audioMixer.SetFloat("Room", Mathf.Lerp(-2500f, -10f, t));
                                Debug.Log(t);
                            }
                            else
                            {
                                // la fora
                                audioMixer.audioMixer.SetFloat("Room", -3000f);
                            }
                        }

                        //tocar um som aleatorio
                        m_AudioSource.PlayOneShot(s.sons[Random.Range(0, s.sons.Count)]);
                    }
                    else
                    {
                        //Debug.LogWarning("Nao encontrou som de passo para material: " + chao.name);
                    }
                }
            }
        }
    }
}
