using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public static BalloonMovement instance;

    public float forceUp = 11f;
    public float forceHorizontal = 5f;
    public float t = 0f;
    public float duration = 50f;

    private bool isMoving = true;

    Rigidbody2D rb;

    public Color color1 = new Color(91f, 213f, 233f);
    public Color color2 = new Color(31f, 31f, 31f);

    public Camera cam;

    private BalloonEnergy balloonEnergy;

    private void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            instance = GetComponent<BalloonMovement>();
            //SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //cam = GetComponent<Camera>();
        balloonEnergy = GetComponent<BalloonEnergy>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    private void Update()
    {
        if(GameManager.instance.isGameOver)
        {
            isMoving = false;
        }

        t = transform.position.y / 50000f;
        if (transform.position.y > 5f)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            cam.backgroundColor = Color.Lerp(color1, color2, t);
        }

    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.AddRelativeForce(Vector2.up * forceUp);

       
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector2.right * forceHorizontal);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector2.left * forceHorizontal);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cloud")
        { 
            rb.drag = 2.7f;
           
        }
        if (other.gameObject.tag == "Hidrogen")
        {
            balloonEnergy.IncreaseEnergy(); 
            Destroy(other.gameObject);

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cloud")
        {
            rb.drag = 1f;

        }
    }
}
