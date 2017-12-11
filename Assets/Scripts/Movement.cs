using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    public float speed_P = 30;
    public float speed_F = 20;
    Rigidbody2D body;
    public float maxSpeed = 2;
    public float forwardSpeed = 2;

    TrailRenderer tr;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        tr = transform.FindChild("Alus").GetComponent<TrailRenderer>();

    }
   
    void Update () {

        MoveForward();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else
        {
            tr.enabled = false;
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

    void MoveForward()
    {
        body.AddRelativeForce(body.velocity.normalized + Vector2.up * speed_F);
       // body.velocity = Vector2.ClampMagnitude(body.velocity, forwardSpeed);

        Vector2 clampVel = body.velocity;
        clampVel.y = Mathf.Clamp(clampVel.y, 0, forwardSpeed);
        body.velocity = clampVel;


    }
    void MoveLeft()
    {
        TrailRenderer tr = transform.FindChild("Alus").GetComponent<TrailRenderer>();
        tr.enabled = true;
        body.AddRelativeForce(body.velocity.normalized + Vector2.left * speed_P);
       // body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);

        Vector2 clampVel = body.velocity;
        clampVel.x = Mathf.Clamp(clampVel.x, (maxSpeed * -1), maxSpeed);
        body.velocity = clampVel;

    }
    void MoveRight()
    {
        TrailRenderer tr = transform.FindChild("Alus").GetComponent<TrailRenderer>();
        tr.enabled = true;
        body.AddRelativeForce(body.velocity.normalized + Vector2.right * speed_P);
        //body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);

        Vector2 clampVel = body.velocity;
        clampVel.x = Mathf.Clamp(clampVel.x, (maxSpeed * -1), maxSpeed);
        body.velocity = clampVel;


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
