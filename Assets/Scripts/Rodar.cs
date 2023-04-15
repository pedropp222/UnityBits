using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodar : MonoBehaviour
{
    [Tooltip("a quantidade de rotacao aplicada em cada eixo a cada frame")]
    public Vector3 quantidadeRodar;

    private void FixedUpdate()
    {
        transform.Rotate(quantidadeRodar.x, quantidadeRodar.y, quantidadeRodar.z);
    }
}
