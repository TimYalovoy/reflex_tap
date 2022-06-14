using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ReflexTap
{
    namespace ReflexTapEventEmitter
    {
        public static class ReflexTapEventEmitter
        {
            #region events: Circle was taped
            private static event Action circleTaped = () => { };
            public static event Action CircleTaped
            {
                add { circleTaped += value; }
                remove { circleTaped -= value; }
            }

            public static void OnCircleTaped()
            {
                circleTaped();
            }

            private static event Action<bool> scoreUpdate = (isIncrease) => { };
            public static event Action<bool> ScoreUpdate
            {
                add { scoreUpdate += value; }
                remove { scoreUpdate -= value; }
            }

            public static void OnScoreUpdate(bool isIncrease = true)
            {
                scoreUpdate(isIncrease);
            }
            #endregion
        }
    }
}

