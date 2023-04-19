using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Instrumento : MonoBehaviour
{
    private TocadorAudio tocador;

    private void Start()
    {
        tocador = gameObject.AddComponent<TocadorAudio>();
    }
}

