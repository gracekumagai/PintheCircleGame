using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    private Text scoreText;
    private int score;

    // Use this for initialization
    void Awake()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();

        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetScore()
    {
        score++;
        scoreText.text = "" + score;
    }
    
}
