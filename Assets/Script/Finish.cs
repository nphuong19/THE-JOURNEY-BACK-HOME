using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
<<<<<<< HEAD
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioManager.PlaySFX(audioManager.finishPoint);
            GameManager.Instance.NextLevel();
        }
            
=======
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            GameManager.Instance.NextLevel();
>>>>>>> origin/main
    }
}
