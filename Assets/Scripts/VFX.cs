using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour, IObserver
{
    private GameObject vfx;

    private float _playTime;
    // Start is called before the first frame update
    void Start()
    {
        vfx = this.gameObject;
        _playTime = vfx.GetComponent<ParticleSystem>().main.duration;
        vfx.SetActive(false);
    }

    public void Active(Transform transform)
    {
        vfx.SetActive(true);
        vfx.transform.position = transform.position;
    }

    private void Update()
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

    public void ReactionToNotification(INotifier notifier)
    {
        Active((notifier as Circle).transform);
    }
}
