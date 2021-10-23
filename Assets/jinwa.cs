using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jinwa : MonoBehaviour
{
    //enum GameStates {PlayerTurn, EnemyTurn, Paused}
    //private GameStates gameState;

    public int floorScore = 0;

    public void win(int dist = 1)
    {
        floorScore += dist;
        Debug.Log(floorScore);
    }

    public void failure(int damage)
    {
        floorScore -= damage;
        Debug.Log(floorScore);
    }

    public void Start()
    {
    }
}
