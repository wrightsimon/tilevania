using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    // Config params
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] float levelExitSpeed = 0.2f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<Player>()) { return; }

        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        Time.timeScale = levelExitSpeed;
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
