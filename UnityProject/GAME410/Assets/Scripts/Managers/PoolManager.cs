using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

// Manage prefab creation, return, and deactivation of objects on a per-prefab basis.
class Pool
{
    GameObject _prefab;
    IObjectPool<GameObject> _pool;

    Transform _root;
    Transform Root
    {
        get
        {
            if (_root == null)
            {
                GameObject go = new GameObject() { name = $"@{_prefab.name}Pool" };
                _root = go.transform;
            }

            return _root;
        }
    }

    public Pool(GameObject prefab)
    {
        _prefab = prefab;
        _pool = new ObjectPool<GameObject>(OnCreate, OnGet, OnRelease, OnDestroy);
    }

    public void Push(GameObject go)
    {
        if (go.activeSelf)
            _pool.Release(go);
    }

    public GameObject Pop()
    {
        return _pool.Get();
    }

    #region Funcs
    GameObject OnCreate()
    {
        GameObject go = GameObject.Instantiate(_prefab);
        go.transform.SetParent(Root);
        go.name = _prefab.name;
        return go;
    }

    void OnGet(GameObject go)
    {
        go.SetActive(true);
    }

    void OnRelease(GameObject go)
    {
        go.SetActive(false);
    }

    void OnDestroy(GameObject go)
    {
        GameObject.Destroy(go);
    }
    #endregion
}

// Manage multiple pools, creates each pool, and provides objects by distinguishing between prefabs.
public class PoolManager
{
    Dictionary<string, Pool> _pools = new Dictionary<string, Pool>();

    /// <summary>
    /// Gets an object from the pool for the given prefab, creating the pool if needed.
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    public GameObject Pop(GameObject prefab)
    {
        if (_pools.ContainsKey(prefab.name) == false)
            CreatePool(prefab);

        return _pools[prefab.name].Pop();
    }

    /// <summary>
    /// Returns an object to the pool if it exists.
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    public bool Push(GameObject go)
    {
        if (_pools.ContainsKey(go.name) == false)
            return false;

        _pools[go.name].Push(go);
        return true;
    }

    /// <summary>
    /// Removes all pools.
    /// </summary>
    public void Clear()
    {
        _pools.Clear();
    }

    /// <summary>
    /// Creates a pool for the specified prefab.
    /// </summary>
    /// <param name="original"></param>
    void CreatePool(GameObject original)
    {
        Pool pool = new Pool(original);
        _pools.Add(original.name, pool);
    }
}
