using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Подписчик. Будет ждать рассылки об изменении состояния объектов. Паттерн: Наблюдатель, Observer
public class VFX : MonoBehaviour
{
    private GameObject vfx;

    private float _playTime;
    // Start is called before the first frame update
    void Start()
    {
        vfx = this.gameObject;
        vfx.SetActive(false);
        _playTime = vfx.GetComponent<ParticleSystem>().main.duration;
    }

    public void Active(Transform transform)
    {
        vfx.transform.position = transform.position;
        vfx.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (vfx.activeSelf)
        {
            if (_playTime == 0)
            {
                vfx.SetActive(false);
            }
            else
            {
                _playTime -= Time.deltaTime;
            }
        }
    }
}
