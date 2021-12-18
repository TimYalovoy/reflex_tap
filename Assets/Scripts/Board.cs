using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private float _height;
    private float _width;

    public float Height {
        get => _height;
        set => _height = value;
    }

    public float Width
    {
        get => _width;
        set => _width = value;
    }

    public PoolObject poolObject;

    // Start is called before the first frame update
    void Start()
    {
        // cache of data
        poolObject = GetComponent<PoolObject>();

        this.Height = 7;
        this.Width = 4;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
