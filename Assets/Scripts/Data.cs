using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    // Board data
    #region Height
    [SerializeField]
    private float _maxHeight = 3f;
    public float MaxHeight
    {
        get => _maxHeight;
        set => _maxHeight = value;
    }
    [SerializeField]
    private float _minHeight = -4f;
    public float MinHeight
    {
        get => _minHeight;
        set => _minHeight = value;
    }
    #endregion

    #region Width
    [SerializeField]
    private float _maxWidth = 2f;
    public float MaxWidth
    {
        get => _maxWidth;
        set => _maxWidth = value;
    }
    [SerializeField]
    private float _minWidth = -2f;
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


}
