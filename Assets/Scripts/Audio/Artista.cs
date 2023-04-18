using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Artista : MonoBehaviour
{
    public string nomeArtista;

    public bool canta;
    public Vector3 tocadorBocaLocal;

    private List<TocadorAudio> tocadores;

    private void Start()
    {
        tocadores = new List<TocadorAudio>();
        if (canta)
        {
            tocadores.Add(Instantiate(UtilsController.instancia.TocadorMusicaPrefab, tocadorBocaLocal, Quaternion.identity, transform).GetComponent<TocadorAudio>());
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (canta)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position + tocadorBocaLocal, Vector3.one / 3);
        }
    }
}