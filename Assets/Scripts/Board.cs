using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ReflexTap
{
    public class Board : MonoBehaviour
    {
        private ReflexTapPoolObject poolObject;
        private Data data;
        private UIHandler uiHandler;
        [SerializeField] private BoardSettings boardSettings;
        [SerializeField] private GamePlaySettings gamePlaySettings;
        [SerializeField] private Image background;
        [SerializeField] private int lives = 3;
        public int Lives
        {
            get => lives;
            protected set
            {
                lives = value;
            }
        }

        public Image Background
        {
            get => background;
            set => background = value;
        }

        public int score = 0;
        public int clicks = 0;

        private bool _gameOver = false;
        public bool isGameOver
        {
            get => _gameOver;
        }

        #region Time to play
        private float _timeToPlay;
        public float TimeToPlay
        {
            get => _timeToPlay;
            protected set { }
        }
        #endregion

        [Header("Reaction Time")]
        [SerializeField] public float delayBeforeCollapse;
        [SerializeField] public float collapsingTime;

        private void Awake()
        {
            ReflexTapEventEmitter.ReflexTapEventEmitter.CircleTaped += ClicksUpdate;
            ReflexTapEventEmitter.ReflexTapEventEmitter.ScoreUpdate += ScoreUpdate;

            poolObject = this.GetComponent<ReflexTapPoolObject>();
            data = this.GetComponent<Data>();
            uiHandler = this.GetComponent<UIHandler>();
            boardSettings = this.GetComponent<BoardSettings>();
            gamePlaySettings = this.GetComponent<GamePlaySettings>();
        }

        private void OnDestroy()
        {
            ReflexTapEventEmitter.ReflexTapEventEmitter.CircleTaped -= ClicksUpdate;
        }

        void Start()
        {
            delayBeforeCollapse = data.Delay;
            collapsingTime = data.TimeToCollapse;
            _timeToPlay = gamePlaySettings.MaxTimeToPlay;
        }

        private void FixedUpdate()
        {
            if (_gameOver || score < 0) GameOver();
        
            TimerToGameOver();
        }

        private void ResetState()
        {
            _gameOver = false;
            score = 0;
            uiHandler.ScoreLabelUpdate(score);
            _timeToPlay = uiHandler.UpdateTimeToPlay(_timeToPlay, gamePlaySettings.MaxTimeToPlay);
            uiHandler.GameOver(false);
        }

        private void TimerToGameOver()
        {
            if (_timeToPlay > 0)
            {
                _timeToPlay -= Time.deltaTime;
                uiHandler.TimeBarUpdate(_timeToPlay);
            } else
            {
                GameOver();
                return;
            }
        }

        private void GameOver()
        {
            _gameOver = true;
            uiHandler.GameOver(true);
            _timeToPlay = uiHandler.ResetTimeToPlay();
            uiHandler.PauseGame();

            StartCoroutine(WaitForStart());
        }

        private IEnumerator WaitForStart()
        {
            yield return new WaitForSecondsRealtime(5f);
            uiHandler.ResumeGame();
            ResetState();
        }

        public void ClicksUpdate()
        {
            clicks++;
        }

        public void ScoreUpdate(bool isIncrease = true)
        {
            score = uiHandler.ScoreMultiplierByClicks(isIncrease, clicks, score);
            _timeToPlay = isIncrease ? uiHandler.UpdateTimeToPlay(_timeToPlay, gamePlaySettings.Reward) :
                uiHandler.UpdateTimeToPlay(_timeToPlay, -gamePlaySettings.Penalty);

        }
    }
}

