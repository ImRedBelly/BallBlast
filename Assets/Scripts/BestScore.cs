using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public Text bestScoreText;
    void Start()
    {
        int bestScore = PlayerPrefs.GetInt(GameManager.keyBestScore);
        bestScoreText.text = "BEST SCORE: " + bestScore;
    }

}
