using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEnterFinish : MonoBehaviour {


    public GameObject finishPanel;
    private int sceneID;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;

            finishPanel.SetActive(true);

            sceneID = SceneManager.GetActiveScene().buildIndex;

            GameState.StagesCleared = sceneID;

            GameState.TotalScore = GameState.TotalScore + GameState.StageScore;
        }

    }
}
