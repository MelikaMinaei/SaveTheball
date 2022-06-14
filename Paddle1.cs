using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1 : MonoBehaviour
{
    [SerializeField] float minY = 1f;
    [SerializeField] float maxY = 15f;
    [SerializeField] float screenWidthInUnits = 16f;
    GameStatus GameSesh;
    Ball theBall;

    void Start()
    {
        GameSesh = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.y = Mathf.Clamp(GetYPos(), minY, maxY);
        transform.position = paddlePos;
    }

    private float GetYPos()
    {
        return Input.mousePosition.y / Screen.width * screenWidthInUnits;
    }
}
