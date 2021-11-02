using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectileSpawnPoint;
    public GameObject minigame;
    public bool hasMinigame;
    public string weakness;
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
        if (!hasMinigame)
        {
            this.Fire();
        }
        else
        {
           GameObject realGame = Instantiate(minigame);
           realGame.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }
    }
}
