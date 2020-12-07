using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioClip backgroundSound;
    public Text score;
    public Text heath;
    public int scorePoint;
    public int heathPoint;

    public static string keyBestScore = "bestRecord";
    void Start()
    {

        AudioManager audioManager = GetComponent<AudioManager>();
        audioManager.PlaySound(backgroundSound);
    }
    void Update()
    {
        score.text = "Score: " + scorePoint;
        heath.text = "Heath: " + heathPoint;
        if(heathPoint <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void AddHealth(int pointHealth)
    {
        heathPoint += pointHealth;
    }
    public void AddScore(int pointScore)
    {
        scorePoint += pointScore;
        SaveBestScore();
    }

    public void SaveBestScore()
    {
        int oldBestScore = PlayerPrefs.GetInt(keyBestScore);
        if (oldBestScore < scorePoint)
        {
            PlayerPrefs.SetInt(keyBestScore, scorePoint);
        }
    }

}
