using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roid : MonoBehaviour {

    public GameObject Alus;
    public GameObject explosion, explosion_sound;
    Rigidbody2D rig;
    public int scoreValue;
    private GameController gameController;

	// Use this for initialization
	void Start () {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");

        }


        Alus = GameObject.FindGameObjectWithTag("Player");
		//this.gameObject.transform.LookAt(Alus.transform);
		rig = this.gameObject.GetComponent<Rigidbody2D> ();


            rig.AddForce((Alus.transform.position - transform.position) * 7f);

    }
    void Update()
    {
        if (transform.position.y < Alus.transform.position.y - 5)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "wall")
        {
            Vector3 v = rig.velocity;
            v.x = -v.x;
            rig.velocity = v;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "greenBall")
        {
            gameController.AddScore(scoreValue);
        }
    }
}