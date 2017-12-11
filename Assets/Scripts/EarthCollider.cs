using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthCollider : MonoBehaviour {

    public AudioClip efect;
    private AudioSource source;
    public bool collision;

    private void Start()
    {

        source = GetComponent<AudioSource>();
        collision = false;
    }
    private void Update()
    {

           
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy1")
        { 
            collision = true;
            source.PlayOneShot(efect);
            //Invoke("Load", 1);

        }
        
    }
    void Load()
    {
        SceneManager.LoadScene(0);
    }

}
