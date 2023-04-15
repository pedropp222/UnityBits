using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Uma classe de escalador, em que aumenta e diminui a escala de um objeto ao longo do tempo
/// </summary>
public class SineScaler : MonoBehaviour
{
    // A escala inicial do objeto
    public Vector3 escalaBase = Vector3.one;

    // A quantidade de escala que vai ser aplicada no objeto
    public Vector3 escalaAmplitude = Vector3.one;

    // A velocidade que a escala muda ao longo do tmepo
    public float escalaVelocidade = 1.0f;

    void Update()
    {
        // Calcular a nova escala baseado na funcao Seno
        Vector3 newScale = escalaBase + escalaAmplitude * Mathf.Sin(Time.time * escalaVelocidade);

        // Aplicar a nova escala no objeto
        transform.localScale = newScale;
    }
}
