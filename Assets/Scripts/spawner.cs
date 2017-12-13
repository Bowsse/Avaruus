using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawner : MonoBehaviour {

	public GameObject[] gos;
    public GameObject alus;
	public List<GameObject> mob = new List<GameObject>();
	float now, refire = 2f;
    public Vector2 center;
    public int curEnemies;
    private int sceneID;

	// Use this for initialization
	void Start () {
		gos = GameObject.FindGameObjectsWithTag("Mobspawner");
        alus = GameObject.FindGameObjectWithTag("Player");
        curEnemies = 0;
		now = Time.time;
	}
    
    // Update is called once per frame
    void Update () {
		
		int i = Random.Range(0, gos.Length-1);

		if (Time.time > now + refire && gos [i].transform.position.y > alus.transform.position.y + 9 && gos[i].transform.position.y < alus.transform.position.y + 19)
        {
            sceneID = SceneManager.GetActiveScene().buildIndex;

            switch (sceneID) { 
                case 1:
                    if (GameObject.FindGameObjectsWithTag("Enemy1").Length < 6 && GameObject.FindGameObjectsWithTag("Enemy2").Length < 4)
                    {
                        now = Time.time;
                        refire = Random.Range(0.3f, 3.0f);
                        var temp = Instantiate(mob[Random.Range(0, mob.Count - 1)]);
                        temp.transform.position = gos[i].transform.position;

                    }
                    break;
                case 2:
                    if (GameObject.FindGameObjectsWithTag("Enemy1").Length < 8 && GameObject.FindGameObjectsWithTag("Enemy2").Length < 15)
                    {
                        now = Time.time;
                        refire = Random.Range(0.3f, 1.0f);
                        var temp = Instantiate(mob[Random.Range(0, mob.Count - 1)]);
                        temp.transform.position = gos[i].transform.position;

                    }
                    break;
            }

		}

    }
}
