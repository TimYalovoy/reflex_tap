using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflexTap
{
    // Singlton
    public class ReflexTapPoolObject : MonoBehaviour
    {
        [SerializeField] private List<GameObject> circles;
        public List<GameObject> Circles
        {
            get => circles;
        }

        #region Singlton
        public static ReflexTapPoolObject Instance;

        private void Awake()
        {
            Instance = this;
        }
        #endregion

        void Start()
        {
            Filling(Circles);
        }

        private void Filling(List<GameObject> gameObjects)
        {
            GameObject go;
            foreach (GameObject prefab in gameObjects)
            {
                go = Instantiate(prefab);
                go.transform.SetParent(this.gameObject.transform);
            }
        }
    }
}
