using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poza : MonoBehaviour
{
    [SerializeField] private GameObject img;
    private void OnMouseDown()
    {
        if(img.activeSelf)
        {
            img.SetActive(false);
        }
        else
        {
            img.SetActive(true);
        }
    }
}
