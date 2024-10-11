<<<<<<< HEAD
﻿using UnityEngine;
=======
using UnityEngine;
>>>>>>> origin/main
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
<<<<<<< HEAD
    public static PauseMenu Instance;
    /*public GameObject pauseMenu;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }*/
    public void Pause()
    {
        
        gameObject.SetActive(true);
        
        Time.timeScale = 0;
        
    }

    public void ResetPauseMenu()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false); // Ẩn giao diện game over
        }
=======
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
>>>>>>> origin/main
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
<<<<<<< HEAD
        
        Time.timeScale = 1;
        GameManager.Instance.ResetScore();
        
=======
        Time.timeScale = 1;
>>>>>>> origin/main
    }

    public void Resume()
    {
<<<<<<< HEAD

        gameObject.SetActive(false);
        
        Time.timeScale = 1;
        
=======
        pauseMenu.SetActive(false);
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
