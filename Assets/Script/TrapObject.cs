using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class TrapObject : MonoBehaviour
{
<<<<<<< HEAD
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
=======
    
>>>>>>> origin/main

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "Player")
        {
<<<<<<< HEAD
            FindObjectOfType<player>().Hurt();
            audioManager.PlaySFX(audioManager.hurt);
=======
            
>>>>>>> origin/main
            FindObjectOfType<HealthBar>().LoseHealth(25);
        }
    }
}
