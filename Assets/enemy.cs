using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectileSpawnPoint;
    public GameObject minigame = null;
    int frameCount;
    int timer;
    // Start is called before the first frame update
    void Start()
    {
        frameCount = 0;
        timer = (int) Random.value * 300;
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
    }
    
    public void Fire()
    {
        GameObject bullet = Instantiate(projectile, projectileSpawnPoint);
        frameCount = 0;
        timer = (int) (Random.value * 300);

    }
    public void Act()
    {
        if (minigame is null)
        {
            this.Fire();
        }
        else
        {
            // put a minigame in here :)
            this.Fire();
        }
    }
}
