using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    // Circle data
    #region Time (seconds)
    [SerializeField]
    private float _delay;
    public float Delay
    {
        get => _delay;
        set => _delay = value;
    }
    [SerializeField]
    private float _timeToCollapse;
    public float TimeToCollapse
    {
        get => _timeToCollapse;
        set => _timeToCollapse = value;
    }
    #endregion
}
