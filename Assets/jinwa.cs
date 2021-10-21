using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jinwa : MonoBehaviour
{
    private int floorscore = 0;
    public void win()
    {
        floorscore += 1;
        Debug.Log(floorscore);
    }

    public void failure(int damage)
    {
        floorscore -= damage;
        Debug.Log(floorscore);
    }
}
