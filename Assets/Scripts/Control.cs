using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Physics))]
public class Control : MonoBehaviour {

    public float speed = 8;
    public float acceleration = 12;
    Rigidbody2D body;
    public float currentSpeed;
    public float targetSpeed;
    public Vector2 amountToMove;

    private Physics physics;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        targetSpeed = Input.GetAxis("Horizontal") * speed;
        currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

        amountToMove = new Vector2(currentSpeed, 0);
        Move(amountToMove);
        /*
        if (Input.GetKey(KeyCode.LeftArrow))
            {
            targetSpeed = -1 * speed;
            currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

            amountToMove = new Vector2(currentSpeed, 0);
            physics.Move(amountToMove);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            targetSpeed = 1 * speed;
            currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

            amountToMove = new Vector2(currentSpeed, 0);
            physics.Move(amountToMove);
        }
        */
    }
    public void Move(Vector2 moveAmount)
    {
        //transform.Translate(moveAmount);
        body.AddRelativeForce(body.velocity.normalized + Vector2.left * moveAmount.magnitude);
    }
    private float IncrementTowards(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }
	
}
