using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public float timeToSpawn = 3.7f;

    public GameObject balloon;

    public List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        balloon = GameObject.Find("BALLOON");
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
       // Vector3 pos = Vector3(1.1, Random.value, someValue);
        
        while (!GameManager.instance.isGameOver)
        {
            //var pos = [];
            //Vector3 leftSpawnPos = new Vector3()
            Vector3 pos = Random.Range(0f, 1f) < 0.5f ? Camera.main.ViewportToWorldPoint(new Vector3(-0.2f, 0f, 1f)) :  Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 0f, 1f));
            /* float randPosY = Random.Range(balloon.transform.position.y + 5f, 10f);
             Vector3 leftV3Pos = Camera.main.ViewportToWorldPoint(new Vector3(-0.2f, 0f, 1f));
             Vector2 leftSpawnPos = new Vector3(leftV3Pos.x, randPosY);

             randPosY = Random.Range(balloon.transform.position.y + 5f, 10f);
             Vector3 rightV3Pos = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 0f, 1f));
             Vector2 rightSpawnPos = new Vector3(rightV3Pos.x, randPosY);
             //int randomPosY = Random.Range(balloon)
             */
            float randPosY = Random.Range(5f, 15f);
            
            Vector2 spawnPos = new Vector3(pos.x, balloon.transform.position.y + randPosY);
            Debug.Log(spawnPos.y);

            if (balloon.transform.position.y > 50 && balloon.transform.position.y <= 150)
                Instantiate(enemies[0], spawnPos, Quaternion.identity);
            else if (balloon.transform.position.y > 150 && balloon.transform.position.y <= 500)
                Instantiate(enemies[1], spawnPos, Quaternion.identity);
            //yield return new WaitForSeconds(timeToSpawn - 1f);

            //Instantiate(enemy, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(timeToSpawn);
        }

    }
}
