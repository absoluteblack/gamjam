using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectileSpawnPoint;
    int frameCount;
    int timer;
    enum State {Idle, Fired};
    State state;
    // Start is called before the first frame update
    void Start()
    {
        frameCount = 0;
        timer = (int) Random.value * 300;
        this.state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount > timer && this.state == State.Idle)
        {
            this.state = State.Fired;
            Debug.Log("Enemy fired");
            GameObject bullet = Instantiate(projectile, projectileSpawnPoint);
        }

    }
}
