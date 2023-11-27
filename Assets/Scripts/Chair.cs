using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public InventoryManager inventoryManager;
    [SerializeField] private GameObject[] Pices;
    [SerializeField] ItemType itemType;
    [SerializeField] private SpriteRenderer Wood;
    [SerializeField] private AudioSource sound;
    private void UseSlectedItem()
    {
        int selectedslot = inventoryManager.selectedSlot;
        if (selectedslot > -1)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (inventoryManager.inventorySlots[selectedslot].GetComponentInChildren<InventoryItem>().item.type == itemType)
                {
                    sound.Play();
                    Item recievedItem = inventoryManager.GetSelectedItem(false);
                    inventoryManager.inventorySlots[selectedslot].Deselect();
                    inventoryManager.selectedSlot = -1;
                    Wood.enabled = true;
                    this.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        UseSlectedItem();
    }
}
