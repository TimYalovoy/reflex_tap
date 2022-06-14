using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflexTap
{
    public class BoardSettings : MonoBehaviour
    {
        [Header("Board size")]

        #region Height
        [SerializeField] private float _maxHeight = 75f;
        public float MaxHeight
        {
            get => _maxHeight;
            protected set { }
        }
        [SerializeField] private float _minHeight = -90f;
        public float MinHeight
        {
            get => _minHeight;
            protected set { }
        }
        #endregion

        #region Width
        [SerializeField] private float _maxWidth = 40f;
        public float MaxWidth
        {
            get => _maxWidth;
            protected set { }
        }
        [SerializeField] private float _minWidth = -40f;
        public float MinWidth
        {
            get => _minWidth;
            protected set { }
        }
        #endregion
    }
}
