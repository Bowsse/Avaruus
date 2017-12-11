using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidMovement : MonoBehaviour
{

    public float speed;
    public float speed_P = 15;
    Rigidbody2D body;
    public float maxSpeed = 2;

    float GetTiltValue()
    {
        float TILT_MIN = 0.07f;
        float TILT_MAX = 0.5f;

        // Work out magnitude of tilt
        float tilt = Mathf.Abs(Input.acceleration.x);

        // If not really tilted don't change anything
        if (tilt < TILT_MIN)
        {
            return 0;
        }
        float tiltScale = (tilt - TILT_MIN) / (TILT_MAX - TILT_MIN);

        // Change scale to be negative if accel was negative
        if (Input.acceleration.x < 0)
        {
            return -tiltScale;
        }
        else
        {
            return tiltScale;
        }

    }

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float tiltValue = GetTiltValue();

        if (tiltValue < 0)
        {
            TrailRenderer tr = transform.FindChild("Alus").GetComponent<TrailRenderer>();
            tr.enabled = true;

            body.AddRelativeForce(body.velocity.normalized + Vector2.right * speed_P * tiltValue);
            //body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);
            Vector2 clampVel = body.velocity;
            clampVel.x = Mathf.Clamp(clampVel.x, (maxSpeed * -1), maxSpeed);
            body.velocity = clampVel;
        }

        if (tiltValue > 0)
        {
            TrailRenderer tr = transform.FindChild("Alus").GetComponent<TrailRenderer>();
            tr.enabled = true;

            body.AddRelativeForce(body.velocity.normalized + Vector2.right * speed_P * tiltValue);
            // body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);
            Vector2 clampVel = body.velocity;
            clampVel.x = Mathf.Clamp(clampVel.x, (maxSpeed * -1), maxSpeed);
            body.velocity = clampVel;
        }
        

        /*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
        }
        */
    }


    /*

    void MoveLeft()
    {
        transform.position += Vector3.left * 5 * Time.deltaTime;
    }
    void MoveRight()
    {
        transform.position += Vector3.right * 5 * Time.deltaTime;
    }
    void MoveUp()
    {
        transform.position += Vector3.up * 5 * Time.deltaTime;
    }
    void MoveDown()
    {
        transform.position += Vector3.down * 5 * Time.deltaTime;
    }
    */
}
