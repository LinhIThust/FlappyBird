using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score,bigScore;
    public bool gameOver = false;
    public Text textScore,endScore,highScore;
    public Button btRestart, btExit;
    public GameObject gameOverText;
    public GameObject menuPanel;
    public BirdMove birdModel;
    public GameObject birdObject;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        bigScore = PlayerPrefs.GetInt("high_score");
        highScore.text = "HIGH SCORE :"+bigScore;
        birdModel = new BirdMove();
        if(birdObject == null)
        {
            birdObject = GameObject.FindGameObjectWithTag("Bird");
        }
        setUpGame();
    }

    public void setUpGame()
    {

        score = 0;
        textScore.text = "SCORE:"+score;
        menuPanel.SetActive(false);
        if(gameOver)
            SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void updateScore()
    {
        if (gameOver) return;
        score++;
        if (score % 3 ==0)
            birdModel.changeColor(birdObject);
        textScore.text = "Score: " + score;
        Debug.Log("" + score);
    }

    public void birdDied()
    {
        gameOver = true;
        menuPanel.SetActive(true);
        updateHighScore();
        textScore.text = "";
        endScore.text = "Score:" + score;
        Debug.Log("EndGame");

    }
    public void changeScene()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Home"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void updateHighScore()
    {
        if (score> bigScore)
        {
            bigScore = score;
            PlayerPrefs.SetInt("high_score", bigScore);
            highScore.text = "HIGH SCORE:" + bigScore;
        }
    }
    
}
