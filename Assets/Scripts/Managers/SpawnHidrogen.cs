using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHidrogen : MonoBehaviour
{
    public GameObject tube;

    private void Start()
    {

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {

        while (!GameManager.instance.isGameOver)
        {

            float randomPosX = Random.Range(-20f, 20f);

            Instantiate(tube, new Vector3(transform.position.x + randomPosX, transform.position.y, 0f), Quaternion.identity);


            yield return new WaitForSeconds(6f);

        }

    }
}
