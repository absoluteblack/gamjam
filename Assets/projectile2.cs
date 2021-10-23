using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile2 : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float initialHSpeed = 0;
    public float hAccel = -1;
    public float initialVSpeed = 0;
    public float vAccel = 0;
    public int damage;
    // TODO - other projectile arcs?
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        rb2D.AddForce(new Vector2(initialHSpeed,initialVSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.AddForce(new Vector2(hAccel,vAccel));
    }
}
