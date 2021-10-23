using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jinwa : MonoBehaviour
{
    enum GameStates {PlayerTurn, EnemyTurn, Paused}
    private GameStates gameState;

    private int floorScore = 0;

    public void win()
    {
        floorScore += 1;
        Debug.Log(floorScore);
    }

    public void failure(int damage)
    {
        if (gameState == GameStates.EnemyTurn)
        {
            // TODO - read damage from projectile in block.cs
            floorScore -= damage;
            Debug.Log(floorScore);
        }
    }

    public void Start()
    {
        gameState = GameStates.EnemyTurn;
    }
}
