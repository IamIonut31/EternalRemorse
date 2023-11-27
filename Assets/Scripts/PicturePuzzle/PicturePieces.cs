using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePieces : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

    [SerializeField] private TextAsset inkJSON;

    public InventoryManager inventoryManager;
    [SerializeField] private GameObject[] Pices;
    [SerializeField] ItemType[] itemType;
    private int NrPices = 0;
    [SerializeField] private GameObject MiniPhoto;

    private void UseSlectedItem()
    {
        int selectedslot = inventoryManager.selectedSlot;
        if (selectedslot > -1)
        {
            for(int i = 0; i <= 3; i++)
            {
                if (inventoryManager.inventorySlots[selectedslot].GetComponentInChildren<InventoryItem>().item.type == itemType[i])
                {
                    Item recievedItem = inventoryManager.GetSelectedItem(true);
                    inventoryManager.inventorySlots[selectedslot].Deselect();
                    inventoryManager.selectedSlot = -1;
                    Pices[i].SetActive(true);
                    NrPices++;
                    sound.Play();
                    break;
                }
            }
        }
        if(NrPices == 4)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            MiniPhoto.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void OnMouseDown()
    {
        UseSlectedItem();
    }
}
