using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//зависимая часть. Будет оповещать о изменении своего состояния. Паттерн: Наблюдатель, Observer
public class Circle : MonoBehaviour
{
    private GameObject go;
    private Transform trfm;
    private SpriteRenderer sprite;
    private Board board;
    private Data data;

    private bool _delayTimerIsDone;
    private bool _reflexTimerIsDone;

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
    private float _coef;
    #region GET SET
    public float Coef
    {
        get => _coef;
        set => _coef = value;
    }
    #endregion

    void Start()
    {
        go = this.gameObject;
        trfm = go.GetComponent<Transform>();
        sprite = go.GetComponent<SpriteRenderer>();
        board = FindObjectOfType<Board>();
        data = board.GetComponent<Data>();
        ResetState();

        _ = Reflex == 0 ? Coef = 1f : Coef = 1f / Reflex;
    }

    private void FixedUpdate()
    {
        TimerToReflex();
    }

    public void ResetState()
    {
        trfm.localScale = new Vector3(1f, 1f);
        trfm.position = new Vector3(
            Random.Range(board.MinWidth, board.MaxWidth),     // x
            Random.Range(board.MinHeight, board.MaxHeight)    // y
            );

        sprite.color = NewColor();

        _delayTimerIsDone = false;
        _reflexTimerIsDone = false;

        this.Delay = data.Delay;
        this.Reflex = data.TimeToCollapse;

        go.SetActive(true);
    }

    public void OnMouseDown()
    {
        _delayTimerIsDone = true;
        _reflexTimerIsDone = true;
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

    private void TimerToReflex()
    {
        if (!_delayTimerIsDone)
        {
            if (Delay > 0)
            {
                Delay -= Time.deltaTime;
            }
            else
            {
                Delay = 0;
                _delayTimerIsDone = true;
            }
        }
        else if (!_reflexTimerIsDone)
        {
            if (Reflex > 0)
            {
                Reflex -= Time.deltaTime;
                trfm.localScale = new Vector3(
                    trfm.localScale.x - (Time.deltaTime * Coef),
                    trfm.localScale.y - (Time.deltaTime * Coef)
                    );
            }
            else
            {
                go.SetActive(false);
                trfm.localScale = new Vector3(0.00f, 0.00f);
                Reflex = 0;
                _reflexTimerIsDone = true;
                board.ScoreDecrease();
                ResetState();
            }
        }
    }
}
