using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {

    public GameObject ProjectilePrefab;
    public float ProjectileSpeed = 10;

    Vector2 direction;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
    
	void Update () {

        //direction = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;

        direction = Vector2.up;

        /*
		if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        */
        Shoot();
	}
    
    void Shoot()
    {

        Vector3 position = new Vector3(transform.position.x, transform.position.y);
        var projectile = Instantiate(ProjectilePrefab, position, transform.rotation);

        projectile.GetComponent<Rigidbody2D>().velocity = direction * ProjectileSpeed;

        
        //Transform clone = Instantiate(mProjectile, GetComponent<Rigidbody2D>().transform.position, Quaternion.identity);
        //clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 1000 * Time.deltaTime);
    }
}
