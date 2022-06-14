using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ReflexTap
{
    public class UIHandler : MonoBehaviour
    {
        public Data data;
        public PauseMenu pauseMenu;

        [SerializeField] private bool showGameOverWindow = true;
        [SerializeField] private BoardSettings boardSettings;
        [SerializeField] private GamePlaySettings gamePlaySettings;

        #region Score
        [SerializeField] private TextMeshProUGUI scoreLabel;
        #endregion

        #region GameOver
        [SerializeField] private TextMeshProUGUI gameOverLabel;
        #endregion

        public TimeBar timeBar;
    
        private int _circleCost;
        private float _penalty;
        private float _reward;

        private void Start()
        {
            data = this.GetComponent<Data>();
            //pauseMenu = this.GetComponent<PauseMenu>();
            timeBar.SetMaxTime(gamePlaySettings.MaxTimeToPlay);
            _circleCost = gamePlaySettings.CircleCost;
            _penalty = gamePlaySettings.Penalty;
            _reward = gamePlaySettings.Reward;
        }
        //zaglushka
        public void PauseGame()
        {
            if (!showGameOverWindow) return;

            pauseMenu.PauseGame();
        }
        //zaglushka
        public void ResumeGame()
        {
            if (!showGameOverWindow) return;

            pauseMenu.ResumeGame();
        }

        public void GameOver(bool gameOver)
        {
            if (!showGameOverWindow) return;

            gameOverLabel.gameObject.SetActive(gameOver);
        }

        public void ScoreLabelUpdate(int score)
        {
            scoreLabel.text = score.ToString();
        }

        public int ScoreIncrease(int score)
        {
            score += _circleCost;

            ScoreLabelUpdate(score);
            return score;
        }

        public int ScoreDecrease(int score)
        {
            score -= _circleCost * (int)_penalty;

            ScoreLabelUpdate(score);
            return score;
        }

        public int ScoreMultiplierByClicks(bool increase, int clicks, int score)
        {
            if (increase)
            {
                return ScoreIncrease(score);
            }
            else
            {
                _ = clicks > 10 ? clicks = 10 : clicks = 0;
                return ScoreDecrease(score);
            }
        }

        public void TimeBarUpdate(float timeToPlay)
        {
            timeBar.SetTime(timeToPlay);
        }

        public float UpdateTimeToPlay(float timeToPlay, bool isReward, float value)
        {
            return isReward ? timeToPlay += value : timeToPlay -= value;
        }
        public float UpdateTimeToPlay(float timeToPlay, float value)
        {
            return timeToPlay += value;
        }

        public float ResetTimeToPlay()
        {
            return 0;
        }
    }
}
