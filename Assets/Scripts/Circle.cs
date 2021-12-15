using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField]
    private GameObject go;
    [SerializeField]
    private Transform tf;

    public bool delayTimerIsDone = false;
    public float secondsDelay = 3f;

    public bool reflexTimerIsDone = false;
    public float secondsReflex = 3f;

    private float coef;
    void Start()
    {
        // кэширование данных
        go = this.gameObject;
        tf.localScale = go.GetComponent<Transform>().localScale;

        try {
            coef = 1f / secondsReflex;
        } catch (Exception e)
        {
            Debug.Log($"Error:{e}");
            coef = 1f;
        }
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!delayTimerIsDone)
        {
            if (secondsDelay > 0)
            {
                secondsDelay -= Time.deltaTime;
            }
            else
            {
                secondsDelay = 0;
                delayTimerIsDone = true;
            }
        }
        else if (!reflexTimerIsDone)
        {
            if (secondsReflex > 0)
            {
                secondsReflex -= Time.deltaTime;
                tf.localScale = new Vector3(tf.localScale.x - (Time.deltaTime * coef), tf.localScale.y - (Time.deltaTime * coef));
            }
            else
            {
                secondsReflex = 0;
                tf.localScale = new Vector3(0.00f, 0.00f);
                go.SetActive(false);
                reflexTimerIsDone = true;
            }
        }
    }
}
