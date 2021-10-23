using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public Sprite blockSprite;
    public Sprite standSprite;
    public bool canBlock = false;
    public bool isBlock;
    int blockStart;
    Animator animator;
    public int floorScore = 0;

    public void win(int dist = 1)
    {
        floorScore += dist;
        Debug.Log(floorScore);
        // TODO - once you go negative you can't recover points anymore? shouldn't matter but wtf
        // TODO - insert test minigame
        // TODO - say something on state transition win/loss/etc

    }

    public void failure(int damage)
    {
        floorScore = Mathf.Max(0, floorScore - damage);
        if (floorScore == 0)
        {
            animator.SetBool("True Loss", true);
            animator.SetInteger("Damage", damage);
            Debug.Log("This one is a true loss");
        }
        else
            animator.SetInteger("Damage", damage);
        Debug.Log(floorScore);
    }

    void Block()
    {
        Debug.Log("Sprite Clicked at :" + blockStart);
        canBlock = false;
        isBlock = true;
    //    this.GetComponent<SpriteRenderer>().sprite = blockSprite;
        blockStart = Time.frameCount;
        animator.SetTrigger("Change Turn");
    }
    void OnMouseDown(){
        if (canBlock)
        {
            Block();

        }
    }

    void OnTriggerEnter2D(Collider2D coll){
        GameObject obj = coll.gameObject;
        projectile2 proj = obj.GetComponent<projectile2>();
        // Literally all possible collisions are projectiles that are either blocked or kill you
        if (!isBlock)
        {
            blockStart = 0;
            // you lose floors, bitch - '0' damage is a true loss
            if (proj.damage == 0)
            {
                animator.SetBool("True Loss", true);
                Debug.Log("true loss, back to start");
            }
            else
            {
                
                Debug.Log("Took damage, heading down " + proj.damage + " floors");
                failure(proj.damage);
            }
        }
        else
        {
            animator.SetTrigger("Change Turn");
            Debug.Log("Bitch blocked!");
        }

    }

    public void Update()
    {
        if (isBlock)
        {
            if (Time.frameCount - blockStart > 120)
            {
                Debug.Log("time to stand");
                isBlock = false;
                //this.GetComponent<SpriteRenderer>().sprite = standSprite;
            }
        }
            
    }
    public void Start()
    {
        canBlock = false;
        animator = GetComponent<Animator>();
    }
}
