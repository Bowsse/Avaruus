using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public GameObject explosion, explosionsound, alus, urth;

    Rigidbody2D rig;
    bool isDone = false;

    Camera mainCamera;

    // Use this for initialization
    void Start()
    {
        // mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rig = gameObject.GetComponent<Rigidbody2D>();

        //rig.AddForce((Input.mousePosition - transform.position).normalized * 85);
        // rig.AddForce((mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)) - transform.position).normalized * 100);
        Destroy(gameObject, 2.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Player" && other.gameObject.name != urth.name && other.gameObject.tag != "wall")
        {
            Destroy(other.gameObject);
            Instantiate(explosion).transform.position = gameObject.transform.position;
            Instantiate(explosionsound).transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }
}
