using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerHouse : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    private void OnMouseDown()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        this.gameObject.SetActive(false);
    }
}
