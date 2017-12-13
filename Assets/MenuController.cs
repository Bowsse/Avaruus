using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {


    public GameObject stageBtn1, stageBtn2;
    public Text totalScoreText;

    public int totalScore;

    void Start()
    {
        if (GameState.TotalScore > 0)
        {
            totalScoreText.text = "Total score: " + GameState.TotalScore.ToString();
        }
        
    }

    public void StageButtons()
    {

        int btnID = 1;
        if (GameState.StagesCleared >= 1)
        {
            btnID = GameState.StagesCleared + 1;
        }
        switch (btnID) {
            case 1:
                stageBtn1.SetActive(true);
                //stageBtn2.SetActive(false);
                break;
            case 2:
                stageBtn2.SetActive(true);
                stageBtn1.SetActive(true);

                break;
            case 3:
                stageBtn2.SetActive(true);
                stageBtn1.SetActive(true);

                break;
        }


    }
}
