using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public static int scoreCount;



    void Update()
    {
    
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
    }
}
