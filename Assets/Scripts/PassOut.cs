using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassOut : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject transitionf;
    private void OnMouseDown()
    {
        StartCoroutine(transition());
    }
    private IEnumerator transition()
    {
        anim.SetTrigger("Start");
        transitionf.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(3);
    }
}
