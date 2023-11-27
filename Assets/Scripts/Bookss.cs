using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookss : MonoBehaviour
{
    public InventoryManager inventoryManager;
    [SerializeField] private GameObject BookPuzzle;
    [SerializeField] ItemType itemType;
    [SerializeField] AudioSource sound;
    private void UseSlectedItem()
    {
        int selectedslot = inventoryManager.selectedSlot;
        if (selectedslot > -1)
        {
                if (inventoryManager.inventorySlots[selectedslot].GetComponentInChildren<InventoryItem>().item.type == itemType)
                {
                    sound.Play();
                    Item recievedItem = inventoryManager.GetSelectedItem(true);
                    inventoryManager.inventorySlots[selectedslot].Deselect();
                    inventoryManager.selectedSlot = -1;
                    BookPuzzle.SetActive(true);
                    this.gameObject.SetActive(false);
                }
        }
    }

    private void OnMouseDown()
    {
        UseSlectedItem();
    }
}
