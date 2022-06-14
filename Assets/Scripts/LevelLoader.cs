using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ReflexTap
{
public class LevelLoader : MonoBehaviour
{
    public GameObject go;
    public Animator transition;

    private void Start()
    {
        go = this.gameObject;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        if (!this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(true);
            Time.timeScale = 1f;
        }
        if (SceneManager.GetActiveScene().name != "MainScene")
        {
            StartCoroutine(LoadLevel(1));
        }
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int index)
    {
        transition.SetTrigger("End");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(index);

        transition.SetTrigger("Start");

        go.SetActive(false);
    }
}
}

