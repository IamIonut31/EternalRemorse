using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour /*, IBeginDragHandler, IDragHandler, IEndDragHandler*/
{
    public Image image;
    [HideInInspector] public Item item;
    [HideInInspector] public Transform parentAfterDrag;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource sound;

    public void InitialiseItem(Item newItem)
    {
        sound.Play();
        anim.Play("Start");
        item = newItem;
        image.sprite = newItem.image;
    }
    /*

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    */
    public void AfterMove()
    {
        sound.Play();
        anim.Play("Move");
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
