using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------------- Audio Source -------------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------------- Audio Clip ---------------------")]
    public AudioClip background;
    public AudioClip landing;
    public AudioClip collectGem;
    public AudioClip collectItem;
    public AudioClip useItem;
    public AudioClip finishPoint;
    public AudioClip playerDeath;
    public AudioClip enemyDeath;
    public AudioClip click;
    public AudioClip hurt;



    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
