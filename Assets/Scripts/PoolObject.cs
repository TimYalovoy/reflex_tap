using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        // rewrite
        GameObject go;
        foreach (GameObject prefab in prefabs)
        {
            go = Instantiate(prefab);
            go.SetActive(false);
            go.transform.SetParent(this.gameObject.transform);
        }
    }

    public void GoOnBoard()
    {

    }
}
