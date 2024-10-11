<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    /*AudioManager audioManager;*/
    public Text scoreText;
    public Text highscoreText;

    /*private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }*/
    public void Winner()
    {
        gameObject.SetActive(true);
        scoreText.text = GameManager.Instance.score.ToString() + " Điểm";
        highscoreText.text = "Điểm kỉ lục: " + GameManager.Instance.highScore.ToString();
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    public void Winner()
    {
        gameObject.SetActive(true);
>>>>>>> origin/main
        Time.timeScale = 0;
    }

    public void Home()
    {
<<<<<<< HEAD
        
        SceneManager.LoadScene("MainMenu");
        
        Time.timeScale = 1;
        GameManager.Instance.ResetScore();
=======
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
>>>>>>> origin/main
    }

}
