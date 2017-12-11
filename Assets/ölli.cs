using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ölli : MonoBehaviour {

    public int rndNum;
    public float speed = 1;
    public float max = 5;
    public GameObject mob, redballPrefab, Alus;
    Rigidbody2D rig;
    public int scoreValue;
    private GameController gameController;

    public Transform redballSpawn;

    public float tChange = 0;


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

        rndNum = 1;
        Alus = GameObject.FindGameObjectWithTag("Player");

        rig = this.gameObject.GetComponent<Rigidbody2D>();
        rig.velocity = Vector3.zero;

    }
    // Update is called once per frame
    void Update() {
        //transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3((Random.value - 0.5f) * speed, 0, (Random.value - 0.5f) * speed), Time.time);

        if (transform.position.y < Alus.transform.position.y - 5)
        {
            Destroy(this.gameObject);
        }
        if (Time.time >= tChange)
        {
            tChange = Time.time + Random.Range(0.5f, 1.5f);
            rndNum = Random.Range(1, 6);
            switch (rndNum)
            {
                case 1:
                    rig.velocity = Vector3.zero;

                    Fire();
                    rig.velocity = Vector3.up * speed/2;

                    

                    break;
                case 2:
                    /*
                    rig.AddRelativeForce(rig.velocity.normalized + Vector2.left * speed);
                    rig.velocity = Vector2.ClampMagnitude(rig.velocity, max);
                    */
                    rig.velocity = Vector3.zero;
                    Fire();
                    rig.velocity = Vector3.up * speed/2 + Vector3.left * speed;

                    //rig.AddForce((rig.velocity.normalized - Vector2.up * speed));


                    break;
                case 3:
                    rig.velocity = Vector3.zero;
                    Fire();


                    rig.velocity = Vector3.up * speed / 2 + Vector3.right * speed;



                    break;
                case 4:
                    rig.velocity = Vector3.zero;
                    Fire();

                    rig.velocity = Vector3.left * speed;

                    break;
                case 5:
                    rig.velocity = Vector3.zero;

                    Fire();
                    rig.velocity = Vector3.right * speed;

                    break;



            }
        }
        
		
	}
    void Fire()
    {
        
        if (redballSpawn.position.y > Alus.transform.position.y + 1.5f && redballSpawn.position.y < Alus.transform.position.y + 5)
        {
            var redball = (GameObject)Instantiate
                (redballPrefab, redballSpawn.position, redballSpawn.rotation);

            Vector3 t = Alus.transform.position;
            t.y = t.y + 2;
            
            Vector3 v = ((t - transform.position).normalized) * 2;
            redball.GetComponent<Rigidbody2D>().velocity = v;
           



           Destroy(redball, 4.0f);
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
