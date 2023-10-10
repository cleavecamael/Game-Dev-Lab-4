using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class HUDManager : Singleton<HUDManager>
{
    public TextMeshProUGUI scoreText;
    public GameObject GameOverPanel;
    public TextMeshProUGUI gameOverText;

    public EventManager eventManager;
    public AudioSource marioAudio;
    public GameManager gameManager;
    public IntVariable score;
    public GameObject highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("adding restart");
        SceneManager.activeSceneChanged += updateScene;
        eventManager.onRestart += Restart;
    }

    public void Restart()
    {
        Debug.Log("Restarting HUD");
        scoreText.text = "Score: 0";
        GameOverPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartButtonCallback(int input)
    {
        // reset everything
        gameManager.ResetGame();
        marioAudio.Stop();
    }
    public void SetScore(int score)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }

    public void updateScene(Scene old, Scene next) {

        if (next.name == "Stage 1-2")
        {
            // change the position accordingly in your World-1-2 case
            SetScore(score.Value) ;
        }
    }
    public void GameOver()
    {
       
        gameOverText.text = scoreText.text;
        GameOverPanel.SetActive(true);
        highscoreText.GetComponent<TextMeshProUGUI>().text = "TOP- " + score.previousHighestValue.ToString("D6");
        // show
        highscoreText.SetActive(true);
    }

}
