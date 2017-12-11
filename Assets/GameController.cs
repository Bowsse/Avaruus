using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


    public GUIText lifeText;
    public GUIText scoreText;
    public GUIText specialTimer;

    public int lives;
    private int score;
    private float special, now, specialText;

    // Use this for initialization
    void Start () {
        lives = 3;
        score = 0;
        special = 0f;
        specialText = 0f;
        UpdateScore();
        UpdateLives();
        now = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        specialTimer.text = "Ultimate CD: " + specialText;

        if (special - (Time.time - now) > 0)
        {
            specialText = System.Convert.ToSingle(Math.Round((special - (Time.time - now)), 2));
        }
	}
    void UpdateLives()
    {
        lifeText.text = "Lives: " + lives;
    }
    public void RemoveLife()
    {
        lives--;
        UpdateLives();
    }
    public void AddLife()
    {

    }
    public void StartSpecialTimer(float megaTimer)
    {
        special = megaTimer;
        now = Time.time;

    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

}
