using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Classe que guarda dados sobre os sons de passos. E possivel criar uma lista de materiais, e nesses materiais
/// definir os sons de passos que se quer. Esses sons vao ser escolhidos e tocados ao calhas.
///
/// </summary>
[CreateAssetMenu(fileName = "Dados", menuName = "ScriptableObjects/Sons Passos Dados", order = 1)]
public class SonsPassosDados : ScriptableObject
{
    [SerializeField]
    List<SomDados> listaDeSons;

    public SomDados GetSomDados(Material material)
    {
        foreach(var s in listaDeSons)
        {
            if (s.materialChao == material)
            {
                return s;
            }
        }

        return null;
    }
}

[System.Serializable]
public class SomDados
{
    public Material materialChao;
    public List<AudioClip> sons;
}