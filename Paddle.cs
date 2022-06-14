using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
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
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
}
