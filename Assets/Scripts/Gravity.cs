using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    Rigidbody2D rig;
    GameObject alus;
    bool isInitialSpeedSet = false;

	// Use this for initialization
	void Start () {
        rig = gameObject.GetComponent<Rigidbody2D>();
        alus = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Use when adding forces to rigidbody
    void FixedUpdate()
    {
        if(isInitialSpeedSet)
        {
            rig.AddForce((alus.transform.position - transform.position).normalized * 9.1f * Time.deltaTime);
        }
        else
        {
            rig.AddForce(Vector2.right.normalized * 25);
            isInitialSpeedSet = true;
        }
        
    }
}
