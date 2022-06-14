using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReflexTap.ReflexTapEventEmitter;
using DG.Tweening;
using System.Linq;

namespace ReflexTap
{
    public class Circle : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private Board board;
        [SerializeField] private BoardSettings boardSettings;
        [SerializeField] private Data data;
        [SerializeField] private CircleCollider2D circleCollider;

        private Sequence sequence;

        [Header("Visual Effects")]
        [SerializeField] private ParticleSystem[] particleSystems;
        [Header("Audio Effect")]
        [SerializeField] private AudioSource tapSFX;

        private float delay;
        private float reflexTime;
        private bool isTaped = false;

        private void Awake()
        {
            ReflexTapEventEmitter.ReflexTapEventEmitter.CircleTaped += OnCircleTaped;

            sprite = this.gameObject.GetComponent<SpriteRenderer>();
            board = FindObjectOfType<Board>();
            boardSettings = board.GetComponent<BoardSettings>();
            data = board.GetComponent<Data>();
            tapSFX = this.gameObject.GetComponent<AudioSource>();
            particleSystems = GetComponentsInChildren<ParticleSystem>();
            circleCollider = GetComponent<CircleCollider2D>();
        }

        private void Start()
        {
            delay = board.delayBeforeCollapse;
            reflexTime = board.collapsingTime;

            VfxOfDestroyIsPlay(particleSystems, false);

            ResetState();

            StopAnimation();
            StartCollapsingAnimation();
        }

        private void StartCollapsingAnimation()
        {
            sequence = DOTween.Sequence();

            sequence.Append(this.gameObject.transform.DOScale(new Vector3(1f, 1f), 0));
            sequence.AppendInterval(delay);
            sequence.Append(this.gameObject.transform.DOScale(new Vector3(0f, 0f), reflexTime));
            sequence.Play();
            sequence.OnComplete(() =>
            {
                if (board.isGameOver) return;

                ResetState();
                board.ScoreUpdate(false);
                sequence.Restart();
            });
        }

        private void StopAnimation()
        {
            sequence.Kill();
        }

        public IEnumerator OnMouseDown()
        {
            if (this.isTaped)
            {
                yield return null;
                Debug.Log($"I musn't logging");
            }

            ReflexTapEventEmitter.ReflexTapEventEmitter.OnCircleTaped();
            ReflexTapEventEmitter.ReflexTapEventEmitter.OnScoreUpdate();

            sprite.color = new Color(0, 0, 0, 0);

            if (tapSFX.isActiveAndEnabled) tapSFX.Play();
            VfxOfDestroyIsPlay(particleSystems, true);

            sequence.Pause();
            //yield return new WaitWhile(() => particleSystems[0].isPlaying);
            yield return new WaitWhile(() => particleSystems.First<ParticleSystem>().isPlaying);

            this.gameObject.SetActive(false);

            ResetState();
        }

        private void OnCircleTaped()
        {
            this.isTaped = true;
            this.circleCollider.enabled = false;
        }

        public void ResetState()
        {
            #region reset changes by Resizing
            this.gameObject.transform.localScale = new Vector3(1f, 1f);
            #endregion

            #region give new random position
            this.gameObject.transform.position = new Vector3
                (
                    Random.Range(boardSettings.MinWidth, boardSettings.MaxWidth),
                    Random.Range(boardSettings.MinHeight, boardSettings.MaxHeight)
                );
            #endregion

            #region give new random color
            sprite.color = NewColor();
            #endregion

            this.gameObject.SetActive(true);
            VfxOfDestroyIsPlay(particleSystems);

            #region reset changes by OnCircleTaped()
            this.isTaped = false;
            circleCollider.enabled = true;
            #endregion

            #region reset animation(DoTween)
            sequence.Rewind();
            sequence.Play();
            #endregion
        }

        private Color NewColor()
        {
            float red = Random.Range(0, 2);
            float green = Random.Range(0, 2);
            float blue = Random.Range(0, 2);
            Color clr = new Color(red, green, blue, 1f);

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

        private void VfxOfDestroyIsPlay(ParticleSystem[] partSystems, bool play = false)
        {
            foreach (ParticleSystem particleSystem in partSystems)
            {
                //_ = play ? particleSystem.Play() : particleSystem.Pause();
                if (play)
                {
                    particleSystem.Play();
                }
                else
                {
                    particleSystem.Pause();
                }
            }
        }

}
}
