using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouse : MonoBehaviour
{
    [SerializeField] private Animator Transition;
    [SerializeField] private GameObject PressE;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(InputManager.GetInstance().GetInteractPressed())
        {
            StartCoroutine(LoadHouseReal());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PressE.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PressE.SetActive(false);
    }
    private IEnumerator LoadHouseReal()
    {
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
