using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    [SerializeField] private Animator Transition;
    public void LoadGame()
    {
        StartCoroutine(LoadGameReal());
    }
    public void LoadHouse()
    {
        StartCoroutine(LoadHouseReal());
    }
    private IEnumerator LoadGameReal()
    {
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
    private IEnumerator LoadHouseReal()
    {
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
