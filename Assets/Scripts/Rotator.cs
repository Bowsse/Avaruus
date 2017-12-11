using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
	}
    void Rotate ()
    {
        transform.Rotate(Vector3.forward * -19 * Time.deltaTime);
    }
}
