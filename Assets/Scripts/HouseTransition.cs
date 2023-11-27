using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTransition : MonoBehaviour
{
    [SerializeField] private int posX;
    [SerializeField] private int posY;
    [SerializeField] private GameObject Camera;
    [SerializeField] private Animator Transition;

    private void OnMouseDown()
    {
        StartCoroutine(ChangeWall());
    }
    private IEnumerator ChangeWall()
    {
        GameObject.Find("WaitForWall").transform.GetChild(0).gameObject.SetActive(true);
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(0.25f);
        Camera.transform.position = new Vector3(posX, posY, -10);
        yield return new WaitForSeconds(0.25f);
        GameObject.Find("WaitForWall").transform.GetChild(0).gameObject.SetActive(false);
    }
}
