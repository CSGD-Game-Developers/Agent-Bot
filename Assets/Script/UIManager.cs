using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Sprite[] lives;
    [SerializeField] private Image livesImageDisplay;

    [SerializeField]private GameObject timerDisplay;
    
    [SerializeField]private int secondsLeft;
    [SerializeField]private bool takingAway = false;

    [SerializeField] GameObject gameOverScreen;

    [SerializeField] private Text currentScore;
    [SerializeField] private Text finalScoreGameOver;
    private int score;

    
    private void Start()
    {  
        timerDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
    }//Start

    private void Update()
    {
        if(takingAway==false && secondsLeft > 0&& !SpawnManager.instance.gamveOver)
        {
            StartCoroutine(TimerTaker());
        }
        if (secondsLeft == 0)
        {
            print("i'm out of lives");
            gameOverScreen.SetActive(true);
            SpawnManager.instance.gamveOver = true;
        }
    }//Update

    IEnumerator TimerTaker()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        timerDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        takingAway = false;
    }//Timer

    public void SetGameOver()
    {
        SpawnManager.instance.gamveOver = true;
        gameOverScreen.SetActive(true);
        finalScoreGameOver.text = currentScore.text;
        currentScore.gameObject.SetActive(true);
    }//GameOver

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        SpawnManager.instance.gamveOver = false;

    }//RestartButton

    public void MainMenu()
    {
        SceneManager.LoadScene(0);

    }//MainMenuButton

    public void UpdateLives(int currentLives)
    {
        if(!SpawnManager.instance.gamveOver)
            livesImageDisplay.sprite = lives[currentLives];

    }//UpdateLives

    public void UpdateScore()
    {
        score += 100;
        currentScore.text = "HIGHEST SCORE " + score;
        
    }//UpdateScore

}//class
