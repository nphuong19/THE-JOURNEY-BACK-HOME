using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSound : MonoBehaviour
{
    AudioSource soure;


    void Start()
    {
        soure = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!soure.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
