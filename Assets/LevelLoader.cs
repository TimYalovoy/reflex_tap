using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject go;
    public Animator transition;

    private void Start()
    {
        go = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().name != "Main")
        {
            return;
        }
        StartCoroutine(LoadLevel(1));
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
