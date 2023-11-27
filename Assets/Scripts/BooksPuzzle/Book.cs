using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

    public GameObject[] Slots;
    public int Tag;
    private bool Moving = false;
    private bool VerifyTransfer = false;

    private float StartPosX;
    private float StartPosY;

    private Vector3 ResetPositon;
    [SerializeField] private int Slotsnr;

    [SerializeField] private float LimR;
    [SerializeField] private float LimL;

    [SerializeField] private float TPR;
    [SerializeField] private float TPL;

    [SerializeField] private GameObject BookPuzzle;

    private void Start()
    {
        ResetPositon = this.transform.localPosition;
    }
    private void OnMouseDown()
    {
        Vector3 MousePos;
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);

        StartPosX = MousePos.x - this.transform.localPosition.x;
        StartPosY = this.transform.localPosition.y;

        Moving = true;
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    private void OnMouseDrag()
    {
        if (Moving)
        {
            Vector3 MousePos;
            MousePos = Input.mousePosition;
            MousePos = Camera.main.ScreenToWorldPoint(MousePos);
            //Debug.Log(MousePos);
            if (MousePos.x < LimL && MousePos.x > LimR)
            {
                //Vector3 newpos = new Vector3(MousePos.x - StartPosX, StartPosY, this.gameObject.transform.localPosition.z);
                //this.gameObject.transform.localPosition = Vector3.Slerp(this.gameObject.transform.localPosition, newpos, 2 * Time.deltaTime);
                this.gameObject.transform.localPosition = new Vector3(MousePos.x - StartPosX, StartPosY, this.gameObject.transform.localPosition.z);
            }
            else
            {
                if (MousePos.x >= LimL)
                    this.gameObject.transform.localPosition = new Vector3(TPL, StartPosY, this.gameObject.transform.localPosition.z);
                if (MousePos.x <= LimR)
                    this.gameObject.transform.localPosition = new Vector3(TPR, StartPosY, this.gameObject.transform.localPosition.z);
            }
            //Debug.Log(MousePos);
        }
    }

    private void OnMouseUp()
    {
        sound.Play();
        Moving = false;
        for (int i = 0; i <= Slotsnr - 1; i++)
        {
            if (Mathf.Abs(this.transform.localPosition.x - Slots[i].transform.localPosition.x) <= 0.5f && Mathf.Abs(this.transform.localPosition.y - Slots[i].transform.localPosition.y) <= 0.5f)
            {
                VerifyTransfer = true;
                Vector3 OldPositon = new Vector3(Slots[i].transform.localPosition.x, Slots[i].transform.localPosition.y, Slots[i].transform.localPosition.z);
                Vector3 OldReset = new Vector3(Slots[i].transform.localPosition.x, Slots[i].transform.localPosition.y, Slots[i].transform.localPosition.z);

                //Slots[i].GetComponent<BooksSlot>().Book.transform.localPosition = ResetPositon;
                Vector3 tempReset = ResetPositon;
                //StartCoroutine(MoveObject(OldPositon, tempReset, 5f));
                //Slots[i].GetComponent<BooksSlot>().Book.GetComponent<Book>().StartCoroutine(MoveObject(OldPositon, tempReset, 5f));
                StartCoroutine(Slots[i].GetComponent<BooksSlot>().Book.GetComponent<Book>().MoveObject(OldPositon, tempReset, 0.5f));
                Slots[i].GetComponent<BooksSlot>().Book.GetComponent<Book>().ResetPositon = ResetPositon;
                //StartCoroutine(MoveObject(Slots[i].GetComponent<BooksSlot>().Book.GetComponent<Book>().ResetPositon, ResetPositon, 5f));

                for (int j = 0; j <= Slotsnr - 1; j++)
                {
                    if (Slots[j].GetComponent<BooksSlot>().BookTag == Tag)
                    {
                        Slots[j].GetComponent<BooksSlot>().Book = Slots[i].GetComponent<BooksSlot>().Book;
                        Slots[j].GetComponent<BooksSlot>().BookTag = Slots[i].GetComponent<BooksSlot>().BookTag;
                        break;
                    }
                }
                Slots[i].GetComponent<BooksSlot>().BookTag = Tag;
                Slots[i].GetComponent<BooksSlot>().Book = this.gameObject;


                this.transform.localPosition = OldPositon;
                //StartCoroutine(MoveObject(this.transform.localPosition, new Vector3(Slots[i].transform.localPosition.x, Slots[i].transform.localPosition.y, Slots[i].transform.localPosition.z), 5f));
                ResetPositon = OldReset;
                //StartCoroutine(MoveObject(ResetPositon, new Vector3(Slots[i].transform.localPosition.x, Slots[i].transform.localPosition.y, Slots[i].transform.localPosition.z), 5f));
                break;
            }
        }
        if (VerifyTransfer == false)
        {
            this.transform.localPosition = new Vector3(ResetPositon.x, ResetPositon.y, ResetPositon.z);
            //StartCoroutine(MoveObject(this.transform.localPosition, new Vector3(ResetPositon.x, ResetPositon.y, ResetPositon.z), 5f));
        }
        VerifyTransfer = false;
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //Debug.Log(this.gameObject);
        BookPuzzle.GetComponent<BooksPuzzleVerify>().VerifyBooksPuzzle();
    }

    public IEnumerator MoveObject(Vector3 source, Vector3 target, float overTime)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        float startTime = Time.time;
        GameObject.Find("WaitForBook").transform.GetChild(0).gameObject.SetActive(true);
        while (Time.time < startTime + overTime)
        {
            transform.localPosition = Vector3.Lerp(source, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        transform.localPosition = target;
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        GameObject.Find("WaitForBook").transform.GetChild(0).gameObject.SetActive(false);
    }
}
