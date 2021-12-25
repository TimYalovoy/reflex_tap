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

    [SerializeField]
    private GameObject[] _vfx;
    public GameObject[] VFX
    {
        get => _vfx;
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
        Filling(Prefabs);
        Filling(VFX);
    }

    private void Filling(GameObject[] gameObjects)
    {
        GameObject go;
        foreach (GameObject prefab in gameObjects)
        {
            go = Instantiate(prefab);
            go.transform.SetParent(this.gameObject.transform);
        }
    }
}
