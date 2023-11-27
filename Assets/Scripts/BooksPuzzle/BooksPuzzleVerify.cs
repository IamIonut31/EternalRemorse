using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksPuzzleVerify : MonoBehaviour
{
    public BooksSlot[] Slots;
    private int verifiedSlots = 0;
    [SerializeField] private int Slotsnr;
    [SerializeField] private GameObject Books;
    [SerializeField] private GameObject SlidingPuzzlePiece;
    [SerializeField] private bool nuj;

    public void VerifyBooksPuzzle()
    {
        for(int i = 0; i <= Slotsnr - 1; i++)
        {
            if(Slots[i].SlotTag == Slots[i].BookTag)
            {
                verifiedSlots++;
                //Debug.Log(verifiedSlots);
            }
        }
        if(verifiedSlots == Slotsnr)
        {
            StartCoroutine(DezactivatePuzzle());
        }
        else
        {
            verifiedSlots = 0;
        }
    }
    private IEnumerator DezactivatePuzzle()
    {
        yield return new WaitForSeconds(0.5f);
        Books.SetActive(true);
        if(nuj == true)
        {
            SlidingPuzzlePiece.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
