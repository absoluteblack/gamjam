using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public Sprite blockSprite;
    public Sprite standSprite;
    enum PlayerStates {Standing, Blocking};
    PlayerStates state;
    int blockStart;

    void Block()
    {
        Debug.Log("Sprite Clicked at :" + blockStart);
    //    this.GetComponent<SpriteRenderer>().sprite = blockSprite;
        blockStart = Time.frameCount;
        this.state = PlayerStates.Blocking;
    }
    void OnMouseDown(){
        if (this.state == PlayerStates.Standing)
            Block();
    }

    void OnTriggerEnter2D(Collider2D coll){
        // Literally all possible collisions are projectiles that are either blocked or kill you
        Debug.Log("Bitch might have been hit?");
        if (this.state != PlayerStates.Blocking)
        {
            // you lose floors, bitch
            Debug.Log("bitch got hit");
            this.GetComponent<jinwa>().failure(1); //TODO - add damage read from projectile
        }
        else
        {
            Debug.Log("Bitch blcoked!");
            this.GetComponent<jinwa>().win();
        }

    }

    public void Update()
    {
        if (this.state == PlayerStates.Blocking)
        {
            if (Time.frameCount - blockStart > 120)
            {
                Debug.Log("yo, time to stand");
                this.state = PlayerStates.Standing;
     //           this.GetComponent<SpriteRenderer>().sprite = standSprite;
            }
        }
    }
    public void Start()
    {
        this.state = PlayerStates.Standing;
    }
}
