using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Board : MonoBehaviour
{
    //[SerializeField]
    private PoolObject poolObject;
    //[SerializeField]
    private Data data;

    private TextMeshProUGUI[] labels;

    #region Height
    //[SerializeField]
    private float _maxHeight = 75f;
    public float MaxHeight
    {
        get => _maxHeight;
    }
    //[SerializeField]
    private float _minHeight = -90f;
    public float MinHeight
    {
        get => _minHeight;
    }
    #endregion

    #region Width
    //[SerializeField]
    private float _maxWidth = 40f;
    public float MaxWidth
    {
        get => _maxWidth;
    }
    //[SerializeField]
    private float _minWidth = -40f;
    public float MinWidth
    {
        get => _minWidth;
    }
    #endregion

    #region Score
    //[SerializeField]
    private int circleCost = 1;
    //[SerializeField]
    private int score = 0;
    //[SerializeField]
    private int clicks = 0;
    private TextMeshProUGUI scoreLabel;
    #endregion

    #region GameOver
    //[SerializeField]
    private bool _gameOver = false;
    private TextMeshProUGUI gameOverLabel;
    #endregion

    #region Time to play
    [SerializeField]
    private float _timeToPlay = 20f;
    //[SerializeField]
    private float _penalty = 2f;
    //[SerializeField]
    private float _reward = 1f;
    #endregion

    void Start()
    {
        // cache of data
        poolObject = this.GetComponent<PoolObject>();
        data = this.GetComponent<Data>();
        labels = FindObjectsOfType<TextMeshProUGUI>();
        if (labels[0].name == "Score Text")
        {
            scoreLabel = labels[0];
            gameOverLabel = labels[1];
            gameOverLabel.gameObject.SetActive(_gameOver);
        } else
        {
            scoreLabel = labels[1];
            gameOverLabel = labels[0];
            gameOverLabel.gameObject.SetActive(_gameOver);
        }
    }

    private void FixedUpdate()
    {
        if (_gameOver)
        {
            ResumeGame();
        }
        TimerToGameOver();
        if (score < 0)
        {
            GameOver();
        }
    }

    private void TimerToGameOver()
    {
        if (_timeToPlay > 0)
        {
            _timeToPlay -= Time.deltaTime;
        } else
        {
            GameOver();
            return;
        }
    }

    private void GameOver()
    {
        _gameOver = true;
        gameOverLabel.gameObject.SetActive(_gameOver);
        _timeToPlay = 0;
        PauseGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        StartCoroutine(WaitForStart());
    }
    private IEnumerator WaitForStart()
    {
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1;
        _gameOver = false;
        score = 0;
        _timeToPlay = 20f;
        gameOverLabel.gameObject.SetActive(false);
    }

    public void ScoreIncrease()
    {
        clicks++;
        _ = clicks > 10 ? score += circleCost * 2 : score += circleCost;
        scoreLabel.text = score.ToString();
        _timeToPlay += _reward;
    }

    public void ScoreDecrease()
    {
        //_ = clicks > 10 ? clicks = 10 : clicks = 0;
        score -= circleCost*3;
        scoreLabel.text = score.ToString();
        _timeToPlay -= _penalty;
    }
}
