using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public Dictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>();

    public void Init()
    {
    }

    [Tooltip("Load resources from the path and return the object.")]
    public T Load<T>(string path) where T : Object
    {
        if (typeof(T) == typeof(Sprite))
        {
            if (_sprites.TryGetValue(path, out Sprite sprite))
                return sprite as T;

            Sprite sp = Resources.Load<Sprite>(path);
            _sprites.Add(path, sp);
            return sp as T;
        }

        Debug.Log($"Load : {path}");

        return Resources.Load<T>(path);

    }

    // TODO : [Dahye] Add Pooling system
    public GameObject Instantiate(string path, Transform parent = null)
    {

        Debug.Log($"Instantiate : {path}");
        GameObject prefab = Load<GameObject>(path);

        if (prefab == null)
        {
            Debug.Log($"Failed to load and Instantiate prefab : {path}");
            return null;
        }

        return Instantiate(prefab, parent);
    }

    public GameObject Instantiate(GameObject prefab, Transform parent = null)
    {
        GameObject go = Object.Instantiate(prefab, parent);
        go.name = prefab.name;
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Object.Destroy(go);
    }
}

// TODO : [Dahye] Check if the resource is loaded or not.