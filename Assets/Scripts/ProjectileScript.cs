using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public float ProjectileSpeed = 100;

    Rigidbody2D rBody;

    private Transform mTransform;
	// Use this for initialization
	void Start () {
       /* mTransform = transform;

        rBody = GetComponent<Rigidbody2D>();
        */
    }
	
	// Update is called once per frame
	void Update () {

        //rBody.AddForce(rBody.transform.forward * ProjectileSpeed * Time.deltaTime);

        //rBody.velocity = rBody.transform.forward * 6 * Time.deltaTime;
        
        /*if(mTransform.position.y > 10 || mTransform.position.x > 10 || mTransform.position.y < -10 || mTransform.position.x < -10)
        {
            Destroy(gameObject);
        }
        */
	}
}
