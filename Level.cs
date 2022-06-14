using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Diagnostics;

public class Level : MonoBehaviour
{
    SceneLoader sceneloader;
    public GameObject camera;

    [SerializeField] int breakableBlocks;
    [SerializeField] int ballsCount;
    [SerializeField] int timesBallFell;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBalls()
    {  
        ballsCount++;
    }

    public void BallsFell()
    {
        timesBallFell++;
        if(CheckLost())
        {
            sceneloader.LoseScene();
        }
    }

    private bool CheckLost()
    {
        if (timesBallFell >= ballsCount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }

    public void ShakeTrigger()
    {
        camera.transform.DOShakePosition(1f, new Vector3(0.02f, 0.02f, 0f), 20, 0.5f, false, false);
    }
}
