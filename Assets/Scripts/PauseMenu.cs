using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflexTap
{
    public class PauseMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        public void PauseGame()
        {
            this.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

