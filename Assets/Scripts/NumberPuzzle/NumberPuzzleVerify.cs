using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberPuzzleVerify : MonoBehaviour
{
    private int[] Numbers = {0, 0, 0, 0};
    [SerializeField] private int[] CorrectNumbers;
    [SerializeField] private TextMeshProUGUI[] Texts;

    private int Index = 0;

    public void IncreaseNr(int i)
    {
        if(Numbers[i] == 9)
        {
            Numbers[i] = 0;
        }
        else
        {
            Numbers[i]++;
        }
        Texts[i].SetText(Numbers[i].ToString());
        PuzzleVerify();
    }
    public void DecreaseNr(int i)
    {
        if (Numbers[i] == 0)
        {
            Numbers[i] = 9;
        }
        else
        {
            Numbers[i]--;
        }
        Texts[i].SetText(Numbers[i].ToString());
        PuzzleVerify();
    }

    private void PuzzleVerify()
    {
        for(int i = 0; i <= 3; i++)
        {
            if(Numbers[i] == CorrectNumbers[i])
            {
                Index++;
            }
        }
        if(Index == 4)
        {
            GameObject.Find("NumberPuzzle").SetActive(false);
        }
        else
        {
            Index = 0;
        }
    }
}
