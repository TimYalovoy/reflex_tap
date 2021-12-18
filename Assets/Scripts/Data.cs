using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    // Board data
    #region Height
    private float _maxHeight;
    public float MaxHeight
    {
        get => _maxHeight;
        set => _maxHeight = value;
    }

    private float _minHeight;
    public float MinHeight
    {
        get => _minHeight;
        set => _minHeight = value;
    }
    #endregion

    #region Width
    private float _maxWidth;
    public float MaxWidth
    {
        get => _maxWidth;
        set => _maxWidth = value;
    }

    private float _minWidth;
    public float MinWidth
    {
        get => _minWidth;
        set => _minWidth = value;
    }
    #endregion

    // Circle data
    #region Time (seconds)
    [SerializeField]
    private float _delay = .65f;
    public float Delay
    {
        get => _delay;
    }
    [SerializeField]
    private float _timeToCollapse = .95f;
    public float TimeToCollapse
    {
        get => _timeToCollapse;
    }
    #endregion

    void Start()
    {
        MaxHeight = 4f;
        MinHeight = -4f;

        MaxWidth = 2f;
        MinWidth = -2f;
    }
}
