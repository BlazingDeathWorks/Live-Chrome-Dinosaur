using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int scoreFactor = 10;
    private int score;

    private void Update()
    {
        score = (int)(Time.deltaTime * scoreFactor);
        scoreText.text = score.ToString();
    }
}
