using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    public Player player;

    [Header("UI Elements")]
    public Text scoreText;
    public GameObject playButton, replayButton, quitButton, gameOver, getReady;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);
        getReady.SetActive(true);
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        replayButton.SetActive(false);
        quitButton.SetActive(false);
        gameOver.SetActive(false);
        getReady.SetActive(false);

        Time.timeScale = 1f;

        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for( int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Quit()
    {
        Debug.Log("quiting");
        Application.Quit();
    }

    public void IncraseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        replayButton.SetActive(true);
        quitButton.SetActive(true);

        Pause();
    }
}
