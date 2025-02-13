using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Speed Management")]
    [SerializeField] private int score;
    public AnimationCurve speedCurve;
    public float levelSpeed;

    [Space]
    [Header("UI")]
    public Text scoreText;
    [SerializeField] GameObject gameOverButton;

    // Start is called before the first frame update
    void Start()
    {
        gameOverButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        levelSpeed = speedCurve.Evaluate(Time.time);

        score = Mathf.FloorToInt(Time.time);
        scoreText.text = $"SCORE: {score}";
    }

    public float GetLevelSpeed()
    {
        return levelSpeed;
    }

    public void GameOverScreen()
    {
        gameOverButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        gameOverButton.SetActive(false);
        Time.timeScale = 1;
        score = 0;
    }

}
