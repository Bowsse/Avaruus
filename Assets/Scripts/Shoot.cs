using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject shootSfx, tykki, plasmaball, explosion, explosionsound, alus, urth;
    float refire = 0.6f, now;
    float megaTimer = 20, megaLast = -19;
    public Transform spawnPoint;
    private GameController gameController;



    GameObject go;
    

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
        now = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > now+refire)
        {
            now = Time.time;
            var bullet = (GameObject)Instantiate(plasmaball, spawnPoint.position, spawnPoint.rotation);

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 6;


            Destroy(bullet, 4.0f);
            Instantiate(shootSfx);

            // go = Instantiate(bullet, spawnPoint);
            //bullet.transform.position = BulletSpawn.position;
            //bullet.transform.position = gameObject.transform.position;

       
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > megaLast + megaTimer)
            {
                megaLast = Time.time;
                gameController.StartSpecialTimer(megaTimer);
                MegaShoot();
            }
        }
    }
    void MegaShoot()
    {
        var bullet1 = (GameObject)Instantiate(plasmaball, spawnPoint.position, spawnPoint.rotation);

        var bullet2 = (GameObject)Instantiate(plasmaball, spawnPoint.position, spawnPoint.rotation);

        var bullet3 = (GameObject)Instantiate(plasmaball, spawnPoint.position, spawnPoint.rotation);

        var bullet4 = (GameObject)Instantiate(plasmaball, spawnPoint.position, spawnPoint.rotation);

        var bullet5 = (GameObject)Instantiate(plasmaball, spawnPoint.position, spawnPoint.rotation);

        var bullet6 = (GameObject)Instantiate(plasmaball, spawnPoint.position, spawnPoint.rotation);


        Vector3 t1 = transform.position;
        t1.y = t1.y + 10;
        Vector3 v1 = ((t1 - transform.position).normalized) * 6;
        bullet1.GetComponent<Rigidbody2D>().velocity = v1;

        Vector3 t2 = transform.position;
        t2.y = t2.y + 10;
        t2.x = t2.x + 5;
        Vector3 v2 = ((t2 - transform.position).normalized) * 6;
        bullet2.GetComponent<Rigidbody2D>().velocity = v2;

        Vector3 t3 = transform.position;
        t3.y = t3.y + 10;
        t3.x = t3.x + 10;
        Vector3 v3 = ((t3 - transform.position).normalized) * 6;
        bullet3.GetComponent<Rigidbody2D>().velocity = v3;

        Vector3 t4 = transform.position;
        t4.y = t4.y + 5;
        t4.x = t4.x + 10;
        Vector3 v4 = ((t4 - transform.position).normalized) * 6;
        bullet4.GetComponent<Rigidbody2D>().velocity = v4;

        Vector3 t5 = transform.position;
        t5.y = t5.y + 5;
        t5.x = t5.x + -10;
        Vector3 v5 = ((t5 - transform.position).normalized) * 6;
        bullet5.GetComponent<Rigidbody2D>().velocity = v5;

        Vector3 t6 = transform.position;
        t6.y = t6.y + 10;
        t6.x = t6.x + -10;
        Vector3 v6 = ((t6 - transform.position).normalized) * 6;
        bullet6.GetComponent<Rigidbody2D>().velocity = v6;
        /*

        bullet2.GetComponent<Rigidbody2D>().velocity = bullet2.transform.up * 6;

        bullet3.GetComponent<Rigidbody2D>().velocity = bullet3.transform.up * 6;

        bullet4.GetComponent<Rigidbody2D>().velocity = bullet4.transform.up * 6;

        bullet5.GetComponent<Rigidbody2D>().velocity = bullet5.transform.up * 6;

        bullet6.GetComponent<Rigidbody2D>().velocity = bullet6.transform.up * 6;
          */

        Destroy(bullet1, 4.0f);
        Destroy(bullet2, 4.0f);
        Destroy(bullet3, 4.0f);
        Destroy(bullet4, 4.0f);
        Destroy(bullet5, 4.0f);
        Destroy(bullet6, 4.0f);
      



    }
}
