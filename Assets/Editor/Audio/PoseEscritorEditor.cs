using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Editor GUI para o PoseEscritor, so adiciona 2 botoes para escrever a pose e fazer reset da pose do artista
/// </summary>
[CustomEditor(typeof(PoseEscritor))]
public class PoseEscritorEditor : Editor
{
    PoseEscritor este = null;

    private void OnEnable()
    {
        este = (PoseEscritor)target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Escrever Pose Atual"))
        {
            este.EscreverOssos(null);
        }
        if (GUILayout.Button("Resetar Pose"))
        {
            este.ResetarOssos(null);
        }
        DrawDefaultInspector();
    }
}
