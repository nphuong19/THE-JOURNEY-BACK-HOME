using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(BoxCollider2D))]

public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, Examine}
    public enum ItemType { Static, Consumables }
    public InteractionType interactType;
    public ItemType itemType;
    public bool stackable = false;
    [Header("Examine")]
    public string descriptionText;
    public UnityEvent customEvent;
    public UnityEvent consumeEvent;
    

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;
    }

    public void Interact()
    {
        switch (interactType)
        {
            case InteractionType.PickUp:
                if(!FindObjectOfType<InventorySystem>().CanPickUp())
                    return;
                
                //them doi tuong vao danh sach da nhat va vo hieu hoa no
                FindObjectOfType<InventorySystem>().PickUp(gameObject);
                gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                //goi examine item tu tep interaction system
                FindObjectOfType<InteractionSystem>().ExamineItem(this);
                break;
            default:
                break;
        }

        customEvent.Invoke();
    }
}
