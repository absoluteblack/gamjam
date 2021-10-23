using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public Sprite blockSprite;
    public Sprite standSprite;

    public bool canBlock;
    public bool isBlock;
    int blockStart;
    Animator animator;

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
            // you lose floors, bitch - '0' damage is a true loss
            if (proj.damage == 0)
            {
                animator.SetTrigger("Loss");
                Debug.Log("true loss, back to start");
            }
            else
            {
                animator.SetInteger("Damage", proj.damage);
                Debug.Log("Took damage, heading down " + proj.damage + " floors");
                this.GetComponent<jinwa>().failure(proj.damage);
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
