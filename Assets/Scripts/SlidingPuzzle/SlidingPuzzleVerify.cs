using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPuzzleVerify : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

    [SerializeField] private SlidingPuzzlePiece[] pieces;
    private bool isCorrect = false;
    private int correctPieces = 0;

    public InventoryManager inventoryManager;
    [SerializeField] ItemType itemType;

    public void PuzzleVerify()
    {
        foreach(var piece in pieces)
        {
            if (piece.Correct == true)
                correctPieces++;
        }
        if(correctPieces == 8)
        {
            isCorrect = true;
            correctPieces = 0;
        }
        else
        {
            correctPieces = 0;
        }
    }
    public void GetSelectedItem()
    {
        PuzzleVerify();
        int selectedslot = GameObject.Find("InventoryManager").GetComponent<InventoryManager>().selectedSlot;
        if (selectedslot > -1)
        {
            if (GameObject.Find("InventoryManager").GetComponent<InventoryManager>().inventorySlots[selectedslot].GetComponentInChildren<InventoryItem>().item.type == itemType && isCorrect)
            {
                sound.Play();
                Item recievedItem = inventoryManager.GetSelectedItem(true);
                GameObject.Find("InventoryManager").GetComponent<InventoryManager>().inventorySlots[selectedslot].Deselect();
                GameObject.Find("InventoryManager").GetComponent<InventoryManager>().selectedSlot = -1;
                GameObject.Find("SlidingPuzzle").SetActive(false);
            }
        }
    }
    private void OnMouseDown()
    {
        GetSelectedItem();
    }
}
