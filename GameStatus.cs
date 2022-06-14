using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 1;
    [SerializeField] int currScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        scoreText.text = currScore.ToString();
    }

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            if (!sceneLoader.CheckFinalScenes())
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currScore += pointsPerBlockDestroyed;
        scoreText.text = currScore.ToString();
    }
}
