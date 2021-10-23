using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTurn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void turnUI()
    {
        //TODO add buttons that do this
        Debug.Log("You fired a lightning bolt haha");
        this.GetComponent<block>().win(1);
        this.GetComponent<Animator>().SetTrigger("Win");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
