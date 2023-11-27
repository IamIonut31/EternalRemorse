using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlidingPuzzleGame : MonoBehaviour
{
    [SerializeField] private Transform empty;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }
    public void Move(GameObject hit)
    {
        if(Vector2.Distance(empty.localPosition, hit.transform.localPosition) < 1.6f)
        {
            Vector2 lastEmptyPosition = empty.localPosition;
            empty.localPosition = hit.transform.localPosition;
            StartCoroutine(hit.GetComponent<SlidingPuzzlePiece>().SmoothMove(lastEmptyPosition));
            //hit.transform.position = lastEmptyPosition;
        }
    }
}
