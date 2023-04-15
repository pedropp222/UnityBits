using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ComponentFinder
{
    public static List<T> Find<T>()
    {
        List<T> components = new List<T>();

        foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            components.AddRange(obj.GetComponentsInChildren<T>());
        }
        return components;
    }
}