using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflexTap
{
    public class Data : MonoBehaviour
    {
        [Header("Circle data")]
        #region Time (seconds) for interact withc Circles
        [SerializeField] private float _delay;
        public float Delay
        {
            get => _delay;
            set => _delay = value;
        }
        [SerializeField] private float _timeToCollapse;
        public float TimeToCollapse
        {
            get => _timeToCollapse;
            set => _timeToCollapse = value;
        }
        #endregion
    }
}
