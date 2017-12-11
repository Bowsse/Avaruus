using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class redball : MonoBehaviour {
    public GameObject explosion, explosion_sound, alus, urth;

    public int scoreValue;
    private GameController gameController;

    Rigidbody2D rig;
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

        rig = gameObject.GetComponent<Rigidbody2D>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "greenBall")
        {
            gameController.AddScore(scoreValue);
        }
    }
}
