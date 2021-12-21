using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private PoolObject poolObject;
    private Data data;

    #region Score
    private int circleCost = 1;
    private int score = 0;
    [SerializeField]
    private int clicks = 0;
    public TextMesh scoreLabel;
    #endregion

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

    #region Time to play
    [SerializeField]
    private float time2play = 20f;
    #endregion

    void Start()
    {
        // cache of data
        poolObject = this.GetComponent<PoolObject>();
        data = this.GetComponent<Data>();
        scoreLabel = FindObjectOfType<TextMesh>();
    }

    public void ScoreIncrease()
    {
        clicks++;
        _ = clicks > 10 ? score += circleCost * 2 : score += circleCost;
        scoreLabel.text = score.ToString();
        time2play += 1.05f;
    }
    public void ScoreDecrease()
    {
        _ = clicks > 10 ? clicks = 10 : clicks = 0;
        score -= circleCost*3;
        scoreLabel.text = score.ToString();
        time2play -= 1f;
    }
}
