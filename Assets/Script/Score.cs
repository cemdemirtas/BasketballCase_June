using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public static Score instance;
    private void Awake() //Singleton Pattern.
    {
        if (instance == null)
        {
            instance = this;
        }

    }


    public void ScoreIncrease(int amount)
    {
        score += amount;
        
    }
}
