using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

    [SerializeField] private TextAsset inkJSON;
    private bool resolved = false;

    [SerializeField] private bool KeepItem;

    public InventoryManager inventoryManager;
    [SerializeField] ItemType itemType;
    public void GetSelectedItem()
    {
        int selectedslot = inventoryManager.selectedSlot;
        if (selectedslot > -1)
        {
            if(inventoryManager.inventorySlots[selectedslot].GetComponentInChildren<InventoryItem>().item.type == itemType)
            {
                if (sound != null)
                {
                    sound.Play();
                }
                Item recievedItem = inventoryManager.GetSelectedItem(false);
                inventoryManager.inventorySlots[selectedslot].Deselect();
                inventoryManager.selectedSlot = -1;
                resolved = true;
                this.gameObject.SetActive(false);
            }
        }
        if (inkJSON != null && resolved == false)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }
    public void UseSlectedItem()
    {
        int selectedslot = inventoryManager.selectedSlot;
        if (selectedslot > -1)
        {
            if (inventoryManager.inventorySlots[selectedslot].GetComponentInChildren<InventoryItem>().item.type == itemType)
            {
                if(sound != null)
                {
                    sound.Play();
                }

                Item recievedItem = inventoryManager.GetSelectedItem(true);
                inventoryManager.inventorySlots[selectedslot].Deselect();
                inventoryManager.selectedSlot = -1;
                resolved = true;
                this.gameObject.SetActive(false);
                
            }
        }
        if (inkJSON != null && resolved == false)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }
    private void OnMouseDown()
    {
        if(KeepItem)
        {
            GetSelectedItem();
        }
        else
        {
            UseSlectedItem();
        }
    }
}
