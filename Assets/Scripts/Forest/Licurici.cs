using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Licurici : MonoBehaviour
{
    private bool playerInRange;
    [SerializeField] private GameObject Licurici1;
    [SerializeField] private GameObject Licurici2;

    private void Update()
    {
        if (playerInRange)
        {
            if (InputManager.GetInstance().GetInteractPressed())
            {
                Licurici1.SetActive(true);
                Licurici2.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
