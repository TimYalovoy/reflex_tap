using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public PoolObject poolObject;

    public Data data;
    // Start is called before the first frame update
    void Start()
    {
        // cache of data
        poolObject = GetComponent<PoolObject>();
        data = GetComponent<Data>();
    }
}
