using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CioaraMovement : MonoBehaviour
{
    SpriteRenderer sprite;
    public float speed = 2f;

    public bool isLeft;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("BALLOON");
        if (player.transform.position.x < transform.position.x)
            isLeft = true;
        else if (player.transform.position.x > transform.position.x)
            isLeft = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isLeft)
        {
            sprite.flipX = true;
            transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);

        }
        else
        {
            sprite.flipX = false;
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);

        }
    }
}

