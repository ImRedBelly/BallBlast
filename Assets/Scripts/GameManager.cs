using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject spawner;
    public GameObject buttonStart;

    public Text textStart;
    public Text textScore;
    public Text textBestScore;

    int score;
    bool isPlay;

    public bool IsPlay { get { return isPlay; } }

    void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void StartGame()
    {
        isPlay = true;
        spawner.SetActive(true);

        score = 0;
        textScore.text = "Score: " + score;
        textBestScore.text = "best score: " + PlayerPrefs.GetInt("bestScore");
    }

    public void GameOver()
    {
        SaveBestScore();
        isPlay = false;
        spawner.SetActive(false);


        textStart.gameObject.SetActive(true);
        textScore.gameObject.SetActive(false);
        textBestScore.gameObject.SetActive(false);

        buttonStart.SetActive(true);

        Block[] blocks = FindObjectsOfType<Block>();
        foreach (Block block in blocks)
            Destroy(block.gameObject);
    }

    public void AddPoint(int pointScore)
    {
        score += pointScore;
        textScore.text = "Score: " + score;
    }

    void SaveBestScore()
    {
        int oldBestScore = PlayerPrefs.GetInt("bestScore");
        if (oldBestScore < score)
            PlayerPrefs.SetInt("bestScore", score);
    }
}
