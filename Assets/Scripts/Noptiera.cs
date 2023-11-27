using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noptiera : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] AudioSource sound;
    private void OnMouseDown()
    {
        sound.Play();
        anim.SetTrigger("Start");
    }
}
