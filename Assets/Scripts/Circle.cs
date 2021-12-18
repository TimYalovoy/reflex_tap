using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject go;
    public Transform trfm;

    private bool delayTimerIsDone = false;
    private bool reflexTimerIsDone = false;

    private float _secondsDelay;
    public float SecondsDelay
    {
        get => _secondsDelay;
        set => _secondsDelay = value;
    }
    private float _secondsReflex;
    public float SecondsReflex
    {
        get => _secondsReflex;
        set => _secondsReflex = value;
    }

    private float coef;

    private void Awake()
    {
        go = this.gameObject;
        trfm.localScale = go.GetComponent<Transform>().localScale;
    }

    void Start()
    {
        ResetState();
        if (SecondsReflex == 0)
        {
            coef = 1f;
        }else{
            coef = 1f / SecondsReflex;    
        }
    }

    private void FixedUpdate()
    {
        if (!delayTimerIsDone)
        {
            if (SecondsDelay > 0)
            {
                SecondsDelay -= Time.deltaTime;
            }
            else
            {
                SecondsDelay = 0;
                delayTimerIsDone = true;
            }
        }
        else if (!reflexTimerIsDone)
        {
            if (SecondsReflex > 0)
            {
                SecondsReflex -= Time.deltaTime;
                trfm.localScale = new Vector3(
                    trfm.localScale.x - (Time.deltaTime * coef),
                    trfm.localScale.y - (Time.deltaTime * coef)
                    );
            }
            else
            {
                go.SetActive(false);
                trfm.localScale = new Vector3(0.00f, 0.00f);
                SecondsReflex = 0;
                reflexTimerIsDone = true;
                ResetState();
            }
        }
    }

    public void ResetState()
    {
        trfm.localScale = new Vector3(1f, 1f);
        trfm.position = new Vector3(
            Random.Range(-2f, 2f), // x
            Random.Range(-4f, 4f)  // y
            );

        delayTimerIsDone = false;
        reflexTimerIsDone = false;

        this.SecondsDelay = 1f;
        this.SecondsReflex = 1.25f;

        go.SetActive(true);
    }

    public void OnMouseDown()
    {
        delayTimerIsDone = true;
        reflexTimerIsDone = true;
        go.SetActive(false);
        ResetState();
    }
}
