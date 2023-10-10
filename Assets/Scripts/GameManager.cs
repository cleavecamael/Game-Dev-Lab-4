using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : Singleton<GameManager>
{
    public GameObject GameOverPanel;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public GameObject player;
    public GameObject enemies;

    public Camera gameCamera;
    public EventManager eventManager;
    //global variables
    public UnityEvent gameStart;
    public UnityEvent gameRestart;
    public  UnityEvent<int> scoreChange;
    public UnityEvent sceneChange;
    public bool alive = true;
    public delegate void RestartEvents();

    public IntVariable score;
    // Start is called before the first frame update
    void Start()
    {
        score.Value = 0;
        gameStart.Invoke();
        Time.timeScale = 1.0f;
        SceneManager.activeSceneChanged += changeScene;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        GetComponent<HUDManager>().GameOver();

    }
    public void GameOverScene()
    {

        // set gameover scene
        GameOver();
    }
    public void ResetGame()
    {
        eventManager.onRestart();
        // reset score
        score.Value = 0;

    }
    public void IncreaseScore(int increment)
    {
        score.ApplyChange(increment);
        SetScore(score.Value);
    }

    public void SetScore(int value)
    {
        score.Value = value;
        scoreChange.Invoke(value);
    }

    public void changeScene(Scene old, Scene curr)
    {
        eventManager.onNextScene();
     
    }

}
