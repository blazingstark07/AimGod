using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    public int score = 0;

    public void PrintScore()
    {
        Debug.Log(score);
    }
}
