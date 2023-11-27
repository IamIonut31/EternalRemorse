using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Usi : MonoBehaviour
{
    [SerializeField] private GameObject Usa;
    [SerializeField] private bool Usa1;
    [SerializeField] private GameObject Nr;

    private void OnMouseDown()
    {
        if(Usa1 == true)
        {
            Nr.SetActive(true);
        }
        Usa.SetActive(false);
    }
}
