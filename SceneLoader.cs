using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] AudioClip[] loseSounds;
    private static string GAME_OVER = "Game Over";
    private static string WIN = "Win";
    AudioSource myAudioSource;
    private string currentScene;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == GAME_OVER)
        {
            AudioClip clip = loseSounds[UnityEngine.Random.Range(0, loseSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }

    public bool CheckFinalScenes()
    {
        if(currentScene == GAME_OVER || currentScene == WIN)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void LoadNextScene()
    {
        int curSceneInd = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curSceneInd + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }

    public void LoseScene()
    {
        SceneManager.LoadScene(GAME_OVER);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
