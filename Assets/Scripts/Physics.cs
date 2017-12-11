using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour {

    Rigidbody2D body;

    public void Move(Vector2 moveAmount)
    {
        //transform.Translate(moveAmount);

        body.AddRelativeForce(body.velocity.normalized + moveAmount);
        
        
    }
    

}
