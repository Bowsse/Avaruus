using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour {

    public float asd;
    public float speed_F = 20;
    Rigidbody2D body;
    public float maxSpeed = 1.0f;

    TrailRenderer tr;

    // Use this for initialization
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        tr = transform.FindChild("Alus").GetComponent<TrailRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        MoveForward();
	}

    void MoveForward()
    {
        body.AddRelativeForce(body.velocity.normalized + Vector2.up * speed_F);
        body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);
    }
}
