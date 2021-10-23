using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCount : MonoBehaviour

{
    public Text numDisplay;
    private int score;

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("Player").GetComponent<block>().floorScore;
        numDisplay.text = score.ToString();
    }
}
