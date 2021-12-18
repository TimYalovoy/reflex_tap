using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabs;
    public GameObject[] Prefabs
    {
        get => _prefabs;
    }

    #region Singlton
    public static PoolObject Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Creating gameObjects in Hierarchy
        GameObject go;
        foreach (GameObject prefab in Prefabs)
        {
            go = Instantiate(prefab);
            go.transform.SetParent(this.gameObject.transform);
        }
    }
}
