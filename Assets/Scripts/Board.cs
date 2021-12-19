using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public PoolObject poolObject;
    public Data data;

    public int circleCost = 20;
    public int score = 0;
    public int clicks = 0;
    public TextMesh scoreLabel;

    void Start()
    {
        // cache of data
        poolObject = GetComponent<PoolObject>();
        data = GetComponent<Data>();
        scoreLabel = FindObjectOfType<TextMesh>();
    }

    private void Update()
    {
        
    }

    public void ScoreIncrease()
    {
        clicks++;
        _ = clicks > 10 ? score += circleCost*clicks : score += circleCost;
        scoreLabel.text = score.ToString();
    }
    public void ScoreDecrease()
    {
        _ = clicks > 10 ? clicks = 10 : clicks = 0;
        score -= circleCost;
        scoreLabel.text = score.ToString();
    }
}
