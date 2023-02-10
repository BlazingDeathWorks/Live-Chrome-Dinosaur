using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int scoreFactor = 10;
    private float score;

    private void Update()
    {
        score += Time.deltaTime * scoreFactor;
        scoreText.text = "Score: " + (int)score;
    }
}
