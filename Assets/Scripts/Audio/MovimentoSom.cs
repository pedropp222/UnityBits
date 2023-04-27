using UnityEngine;

/// <summary>
/// Classe para mover uma parte do corpo de um artista, baseado no som que o instrumento
/// esta a fazer no momento. Esta classe é baseada numa implementação que ja foi feita ha
/// bastante tempo, com algumas pequenas alterações para ficar melhor apresentável, mas
/// vai necessitar de uma revisão para melhor a qualidade.
/// </summary>
namespace Audio
{
    [RequireComponent(typeof(Instrumento))]
    public class MovimentoSom : MonoBehaviour
    {
        private Transform parte;

        private float intensidade;
        private float suavidade;

        private AudioSource audioS;

        float rotacaoInicial;
        float rotAtual;
        float[] espectro;

        /// <summary>
        /// Este script requer o audio source do instrumento para funcionar
        /// </summary>
        private void Start()
        {
            parte = transform;
            rotacaoInicial = parte.localEulerAngles.x;
            rotAtual = rotacaoInicial;
            espectro = new float[256];
        }

        //Apenas o Instrumento vai ou pode chamar este metodo, quando o carregador finalmente carrega um som.
        public void SetAudioSource(AudioSource audio)
        {
            audioS = audio;
        }

        private void Update()
        {
            if (audioS == null || parte == null) return;

            float media = 0f;

            audioS.GetOutputData(espectro, 0);

            for (int i = 0; i < espectro.Length; i++)
            {
                media += espectro[i] * intensidade;
            }

            if (media < 0f) media *= -1f;

            rotAtual = Mathf.Lerp(rotAtual, rotacaoInicial + media, 1f - suavidade);

            Vector3 novaRot = new Vector3(rotAtual, parte.localEulerAngles.y, parte.localEulerAngles.z);

            parte.localEulerAngles = novaRot;
        }

        public void SetIntensidade(float valor)
        {
            intensidade = valor;
        }

        public void SetSuavidade(float valor)
        {
            suavidade = valor;
        }

    }
}