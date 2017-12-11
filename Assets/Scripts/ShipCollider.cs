using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipCollider : MonoBehaviour
{
    public AudioClip blip;
    public Rigidbody2D rb;
    private AudioSource source;
    public GameObject explosion, explosion_sound, Player, DeathSound;
    public bool collision;
    float now, immune = 2f;
    public int lives;
    private GameController gameController;


    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");

        }

        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        source = GetComponent<AudioSource>();
        collision = false;
        now = Time.time;
    }
    private void Update()
    {


    }
    void Damage(GameObject other)
    {
        if (Time.time > now + immune)
        {
            now = Time.time;
            collision = false;
            if (other.gameObject.tag == "Enemy1" || other.gameObject.tag == "wall" || other.gameObject.tag == "Enemy2" || other.gameObject.tag == "projectile" )
            {
                if (collision == false)
                {
                    float randomRotation = 0f;
                    randomRotation = Random.Range(-1000, 1000);
                    if (gameController.lives < 1)
                    {
                        GameObject go = Instantiate(explosion);

                        go.transform.position = this.gameObject.transform.position;
                        go.transform.Rotate(Vector3.forward * -randomRotation);
                        float i = Random.Range(5.0f, 7.5f);
                        go.transform.localScale = new Vector3(i, i, i);
                        GameObject ds = Instantiate(DeathSound);
                        Destroy(go, 4);
                        Invoke("Load", 0.4f);
                    }
                    else
                    {
                        GameObject go = Instantiate(explosion);

                        go.transform.position = this.gameObject.transform.position;
                        go.transform.Rotate(Vector3.forward * -randomRotation);
                        float i = Random.Range(3.0f, 4.5f);
                        go.transform.localScale = new Vector3(i, i, i);

                        go = Instantiate(explosion_sound);

                        Destroy(go, 4);


                        collision = true;


                        Invoke("Respawn", 0.4f);
                    }
                    


                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Damage(other.gameObject);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Damage(other.gameObject);
    }

    void Load()
    {
        collision = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Respawn()
    {

        //Player.transform.position = new Vector2(0, this.transform.position.y);
        //Player.transform.rotation = new Quaternion(0, 0, 0, 0);
        rb.velocity = new Vector2(0, 0);
        rb.position = new Vector2(0, this.transform.position.y);

        gameController.RemoveLife();


    }

}
