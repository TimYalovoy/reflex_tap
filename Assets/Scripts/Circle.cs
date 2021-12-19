using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject go;
    public Transform trfm;
    public Data data;
    public SpriteRenderer sprite;

    private bool delayTimerIsDone;
    private bool reflexTimerIsDone;

    private float _delay;
    #region GET SET
    public float Delay
    {
        get => _delay;
        set => _delay = value;
    }
    #endregion
    private float _reflex;
    #region GET SET
    public float Reflex
    {
        get => _reflex;
        set => _reflex = value;
    }
    #endregion
    private float coef;
    private Board board;

    void Start()
    {
        go = this.gameObject;
        data = GetComponent<Data>();
        sprite = GetComponent<SpriteRenderer>();
        trfm = GetComponent<Transform>();
        board = FindObjectOfType<Board>();
        ResetState();
        if (Reflex == 0)
        {
            coef = 1f;
        }else{
            coef = 1f / Reflex;
        }
    }

    private void FixedUpdate()
    {
        if (!delayTimerIsDone)
        {
            if (Delay > 0)
            {
                Delay -= Time.deltaTime;
            }
            else
            {
                Delay = 0;
                delayTimerIsDone = true;
            }
        }
        else if (!reflexTimerIsDone)
        {
            if (Reflex > 0)
            {
                Reflex -= Time.deltaTime;
                trfm.localScale = new Vector3(
                    trfm.localScale.x - (Time.deltaTime * coef),
                    trfm.localScale.y - (Time.deltaTime * coef)
                    );
            }
            else
            {
                go.SetActive(false);
                trfm.localScale = new Vector3(0.00f, 0.00f);
                Reflex = 0;
                reflexTimerIsDone = true;
                board.ScoreDecrease();
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
        
        sprite.color = NewColor();
        
        delayTimerIsDone = false;
        reflexTimerIsDone = false;

        this.Delay = data.Delay;
        this.Reflex = data.TimeToCollapse;

        go.SetActive(true);
    }

    public void OnMouseDown()
    {
        delayTimerIsDone = true;
        reflexTimerIsDone = true;
        go.SetActive(false);
        board.ScoreIncrease();
        ResetState();
    }

    private Color NewColor()
    {
        Color clr = new Color();
        clr.r = Random.Range(0, 2);
        clr.g = Random.Range(0, 2);
        clr.b = Random.Range(0, 2);
        clr.a = 1f;

        if (clr == Color.black)
        {
            // power up
            clr = Color.blue;
        }
        if (clr == Color.white)
        {
            // power up
            clr = Color.cyan;
        }

        return clr;
    }
}
