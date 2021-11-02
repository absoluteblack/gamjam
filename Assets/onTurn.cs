using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTurn : MonoBehaviour
{
    
    Animator animator;
    public GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void turnUI()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
            //TODO - not all buttons are always active - should be gone during EnemyTurn
        }
    }

    public void attack(string type)
    {
        if (type == GameObject.Find("Enemy").GetComponent<enemy>().weakness)
        {
            Debug.Log("killed this fool");
            GetComponent<block>().win();
        }
        else
        {
            Debug.Log("This attack did not hurt the enemy");
            animator.SetTrigger("Change Turn");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
