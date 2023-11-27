using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private GameObject Something1;
    [SerializeField] private GameObject Something2;
    [SerializeField] private Light2D Mylight;

    private bool playerInRange;

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                if(Something1 != null)
                {
                    Something1.SetActive(true);
                }
                if (Something2 != null)
                {
                    Something2.SetActive(true);
                }
            Mylight.intensity = Mylight.intensity - 0.2f;
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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
