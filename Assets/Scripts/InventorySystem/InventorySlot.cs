using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler//, IDropHandler
{


    public Image image;
    public Color selectedColor, notSelectedColor;
    public InventoryManager inventoryManager;

    private void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        image.color = selectedColor;
    }
    public void Deselect()
    {
        image.color = notSelectedColor;
    }
    /*
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
    */
    public void OnPointerClick(PointerEventData eventData)
    {
        int selectedslot = inventoryManager.selectedSlot;
        if (transform.childCount == 0)
        {
            if(selectedslot > -1)
            {
                inventoryManager.inventorySlots[selectedslot].Deselect();
                InventoryItem inventoryItem = inventoryManager.inventorySlots[selectedslot].GetComponentInChildren<InventoryItem>(); //GetComponent<InventoryItem>();
                inventoryItem.parentAfterDrag = transform;
                inventoryItem.AfterMove();
                inventoryManager.selectedSlot = -1;
            }
        }
        else
        {
            int thisSlotIndex = System.Array.IndexOf(inventoryManager.inventorySlots, this.gameObject.GetComponent<InventorySlot>());
            if(selectedslot == thisSlotIndex)
            {
                Deselect();
                inventoryManager.selectedSlot = -1;
            }
            else
            {
                inventoryManager.ChangeSelectedSlot(System.Array.IndexOf(inventoryManager.inventorySlots, this.gameObject.GetComponent<InventorySlot>()));
            }
            //Debug.Log(System.Array.IndexOf(GameObject.Find("InventoryManager").GetComponent<InventoryManager>().inventorySlots, this.gameObject.GetComponent<InventorySlot>()));
        }
    }
}
