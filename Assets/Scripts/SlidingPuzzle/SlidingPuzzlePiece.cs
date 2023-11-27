using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlidingPuzzlePiece : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

    private float desiredDuration = 0.1f;
    private float timeStart;
    public Vector3 CorrectPosition;
    public bool Correct = false;
    private void OnMouseDown()
    {
        GameObject.Find("SlidingPuzzle").GetComponent<SlidingPuzzleGame>().Move(this.gameObject);
    }
    public IEnumerator SmoothMove(Vector2 lastEmptyPos)
    {
        sound.Play();
        Vector2 startPos = this.transform.localPosition;
        timeStart = Time.time;
        while (Time.time < timeStart + desiredDuration)
        {
            transform.localPosition = Vector3.Lerp(startPos, lastEmptyPos, (Time.time - timeStart) / desiredDuration);
            yield return null;
        }
        this.transform.localPosition = lastEmptyPos;
        if(this.transform.localPosition == CorrectPosition)
        {
            Correct = true;
        }
        else
        {
            Correct = false;
        }
    }
    private void Start()
    {
        if (this.transform.localPosition == CorrectPosition)
        {
            Correct = true;
        }
        else
        {
            Correct = false;
        }
    }
}
