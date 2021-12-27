using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private GameObject player;
    public static float score;
    private float highScore;
    private float lastPos = 0f;

    public Text scoreText;
    public Text highScoreText;


    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore");
        player = GameObject.FindGameObjectWithTag("player");
    }
    void Update()
    {
        CheckDistance();


        scoreText.text = "Score : " + score.ToString("0");
        highScoreText.text = "HighScore : " + highScore.ToString("0");

        SetHighScore();

    }

    private void CheckDistance()
    {
        if (player.transform.position.z - lastPos > 10f) //distance parcourrue 
        {
            score++;

            lastPos = player.transform.position.z;
        }
    }
    private void SetHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
    }
}