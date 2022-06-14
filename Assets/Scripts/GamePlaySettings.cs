using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflexTap
{
    public class GamePlaySettings : MonoBehaviour
    {
        [Header("Game settings")]
        #region Time to play
        [SerializeField] private float _maxTimeToPlay;
        public float MaxTimeToPlay
        {
            get => _maxTimeToPlay;
            set => _maxTimeToPlay = value;
        }
        #endregion

        #region Circle Cost
        [SerializeField] private int _circleCost;
        public int CircleCost
        {
            get => _circleCost;
        }
        #endregion

        #region Penalty for player misstake
        [SerializeField] private float _penalty;
        public float Penalty
        {
            get => _penalty;
            set => _penalty = value;
        }
        #endregion

        #region Reward for successfull interact with circle
        [SerializeField] private float _reward;
        public float Reward
        {
            get => _reward;
            set => _reward = value;
        }
        #endregion
    }
}
