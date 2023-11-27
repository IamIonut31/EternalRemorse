using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItem : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if(result == false)
        {
            Debug.Log("Inventory Full");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnMouseDown()
    {
        PickupItem(0);
    }
}
