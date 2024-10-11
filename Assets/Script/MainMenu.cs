<<<<<<< HEAD
﻿using System.Collections;
=======
using System.Collections;
>>>>>>> origin/main
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
<<<<<<< HEAD
    /*AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }*/
=======
>>>>>>> origin/main
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame()
    {
        Application.Quit();
<<<<<<< HEAD
        
=======
>>>>>>> origin/main
    }
}
