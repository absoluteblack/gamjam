using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public Sprite blockSprite;
    public Sprite standSprite;
    public bool canBlock = false;
    public bool isBlock = false;
    int blockStart;
    Animator animator;
    public int floorScore = 1;
    public AudioSource BlockSound;
    public AudioSource PortalSound;
    public void win(int dist = 1)
    {
        floorScore += dist;
        Debug.Log(" now at floor " + floorScore);
        // TODO - say something on state transition win/loss/etc
        animator.SetTrigger("Win");
    }

    public void failure(int damage)
    {
        floorScore = Mathf.Max(0, floorScore - damage);
        if (floorScore == 0)
        {
            PortalSound.Play();
            animator.SetBool("True Loss", true);
            animator.SetInteger("Damage", damage);
        }
        else
            PortalSound.Play();
            animator.SetInteger("Damage", damage);
        Debug.Log("now at floor " + floorScore);
    }

    void Block()
    {
        canBlock = false;
        isBlock = true;
    //    this.GetComponent<SpriteRenderer>().sprite = blockSprite;
        blockStart = Time.frameCount;
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
            }
            else
            {
                Debug.Log("Took damage, heading down " + proj.damage + " floors");
                failure(proj.damage);
            }
        }
        else
        {
            BlockSound.Play();
            animator.SetTrigger("Change Turn");
            Debug.Log("Bitch blocked!");
        }
        
        Destroy(GameObject.FindGameObjectWithTag("Projectile"));
    }

    public void Update()
    {
        if (isBlock)
        {
            if (Time.frameCount - blockStart > 20)
            {
                isBlock = false;
                //this.GetComponent<SpriteRenderer>().sprite = standSprite;
            }
        }
            
    }
    public void Start()
    {
        Application.targetFrameRate = 60;
        canBlock = false;
        animator = GetComponent<Animator>();
    }
}
