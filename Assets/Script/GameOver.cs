<<<<<<< HEAD
﻿
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance;
    /*AudioManager audioManager;*/
    public Text scoreText;
    public Text highscoreText;

    /*private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }*/
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
>>>>>>> origin/main

    public void gameOver()
    {
        gameObject.SetActive(true); // Hiển thị giao diện game over
<<<<<<< HEAD
        scoreText.text = GameManager.Instance.score.ToString() + " Điểm";
        highscoreText.text = "Điểm kỉ lục: " + GameManager.Instance.highScore.ToString();
=======
        
>>>>>>> origin/main
    }

    public void ResetGameOverUI()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false); // Ẩn giao diện game over
        }
    }

    public void Home()
    {
<<<<<<< HEAD
       
        SceneManager.LoadScene("MainMenu");
        
        gameObject.SetActive(false);
        Time.timeScale = 1;
        GameManager.Instance.ResetScore();

=======
        SceneManager.LoadScene("MainMenu");
        gameObject.SetActive(false);
        Time.timeScale = 1;
        
>>>>>>> origin/main
    }

    public void Restart()
    {
<<<<<<< HEAD
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        Time.timeScale = 1;
        GameManager.Instance.NewGame();
        
=======
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        GameManager.Instance.NewGame();
>>>>>>> origin/main
    }
}
