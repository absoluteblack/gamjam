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
        // TODO - once you go negative you can't recover points anymore? shouldn't matter but wtf
        // TODO - handle floorScore <= 0 is a true loss 
        // TODO - insert test minigame
        // TODO - say something on state transition win/loss/etc

    }

    public void failure(int damage)
    {
       // floorScore = Math.Min(0, floorScore - damage);
        Debug.Log(floorScore);
    }

    public void Start()
    {
    }
}
