using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile2 : MonoBehaviour
{
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.AddForce(new Vector2(-1,0));
    }
}
