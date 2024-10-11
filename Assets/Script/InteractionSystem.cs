using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    [Header("Detection")]
    // diem phat hien
    public Transform detectionPoint;
    // ban kinh vong phat hien
    private const float detectionRadius = 0.2f;
    // lop phat hien
    public LayerMask detectionLayer;
    // tao doi tuong kich hoat
    public GameObject detectedObject;

    [Header("Examine")]
    public GameObject examineWindow;
    public Image examineImage;
    public Text examineText;
    public bool isExamining;

<<<<<<< HEAD
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
=======
    
>>>>>>> origin/main

    void Update()
    {
        if (DetectObject())
        {
            if(InteractInput())
            {
                detectedObject.GetComponent<Item>().Interact();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
<<<<<<< HEAD

=======
>>>>>>> origin/main
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position,detectionRadius,detectionLayer);
        if(obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }


    public void ExamineItem(Item item)
    {
        if(isExamining)
        {
            examineWindow.SetActive(false);
            isExamining = false;
<<<<<<< HEAD
            audioManager.PlaySFX(audioManager.collectItem);
=======
>>>>>>> origin/main
        }
        else
        {
            examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
            examineText.text = item.descriptionText;
            examineWindow.SetActive(true);
            isExamining = true;
<<<<<<< HEAD
            audioManager.PlaySFX(audioManager.collectItem);
=======
>>>>>>> origin/main
        }
        
    }
}
