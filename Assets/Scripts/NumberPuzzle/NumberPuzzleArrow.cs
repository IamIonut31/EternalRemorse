using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumberPuzzleArrow : MonoBehaviour
{
    [SerializeField] private bool Up;
    [SerializeField] private int Number;
    [SerializeField] private AudioSource sound;
    private void OnMouseDown()
    {
        if(Up)
        {
            sound.Play();
            GameObject.Find("NumberPuzzle").GetComponent<NumberPuzzleVerify>().IncreaseNr(Number);
        }
        else
        {
            sound.Play();
            GameObject.Find("NumberPuzzle").GetComponent<NumberPuzzleVerify>().DecreaseNr(Number);
        }
    }
}
