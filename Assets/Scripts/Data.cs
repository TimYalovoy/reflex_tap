using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
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
