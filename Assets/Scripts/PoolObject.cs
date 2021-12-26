using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _circles;
    public List<GameObject> Circles
    {
        get => _circles;
    }

    [SerializeField]
    private List<GameObject> _vfx;
    public List<GameObject> VFX
    {
        get => _vfx;
    }

    #region Singlton
    public static PoolObject Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Creating gameObjects in Hierarchy
        Filling(Circles);
        Filling(VFX);

        VFX[0].SetActive(true);
        VFX vfx = VFX[0].GetComponent<VFX>();
        foreach (GameObject circle in Circles)
        {
            circle.GetComponent<Circle>().Attach(vfx);
        }
        VFX[0].SetActive(false);

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
