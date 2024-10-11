using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPoint : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField]private Win winUI;
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
            winUI.Winner();
        }
            
=======
    [SerializeField] private Win winUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            winUI.Winner();
>>>>>>> origin/main
    }
}
