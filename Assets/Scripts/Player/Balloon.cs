using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{

    public float maxEnergy;
    public float currentEnergy;
    public float force = 5f;
    public float t = 0f;

    public Color color1 = Color.red;
    public Color color2 = Color.blue;

   // public Camera cam;

    public Slider slider;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
        slider.maxValue = maxEnergy;
        rb = GetComponent<Rigidbody2D>();
       // cam = GetComponent<Camera>();
       //cam.clearFlags = CameraClearFlags.SolidColor;
    }


    void Update()
    {
        /*t = transform.position.y / 5000f;
        if (transform.position.y > 5f)
        {
            //float t = Mathf.PingPong(Time.time, duration) / duration;
            cam.backgroundColor = Color.Lerp(color1, color2, t);
        }
        */

        //Health();

        if(currentEnergy <= 0f)
        {
            EndDay();
        }
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * force);

        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * 5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * 5f);
        }
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            force = 30f;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            force = 11f;
        }
        */  
        Debug.Log(rb.velocity);

    }

    void Health()
    {
        if(currentEnergy > 0f)
        {
            currentEnergy -= 0.01f;
            SetHealthUI();
        }
    }

    void SetHealthUI()
    {
        slider.value = currentEnergy;
    }

    void EndDay()
    {
        Destroy(gameObject);
    }

}
