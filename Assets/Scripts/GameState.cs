using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState {

	public static int TotalScore { get; set; }
    public static int StageScore { get; set; }

    private static int stagesCleared = 0;
    public static int StagesCleared {
        get 
        {
            return stagesCleared;
        }
        set
        {
            if (value >= stagesCleared)
            {
                stagesCleared = value;
            }
        }
    }

}
