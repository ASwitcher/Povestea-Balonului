using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonLives : MonoBehaviour
{
    private static BallonLives ballonLives;

    public int numberOfLives = 1;


    private void Update()
    {
        if(numberOfLives <= 0 && !GameManager.instance.isGameOver)
        {
            GameManager.instance.GameOver();
        }
    }

    public void LoseLife()
    {
        numberOfLives--;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            if (!GameManager.instance.isGameOver)
            {
                LoseLife();
                Destroy(collision.gameObject);
                Debug.Log("Number of lives: " + numberOfLives);
            }
        }
    }
}
