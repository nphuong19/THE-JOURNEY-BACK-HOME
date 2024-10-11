using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider2D))]
public class Gem : MonoBehaviour
{
   
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.tag = "Gem";
    }

    
   
}
