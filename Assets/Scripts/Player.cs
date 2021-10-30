using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int life;
    public int score;

    public bool isDead;
    public bool hasWon;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        score = 0;
        isDead = false;
        hasWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0 && !isDead)
        {
            isDead = true;
        }
    }
}
