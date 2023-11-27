using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : PhysicsObject
{
    [Header("Attributes")]
    [SerializeField] private float maxSpeed = 1;

    [Header("References")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private Animator anim;
    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.SetFloat("velocityX", 0);
                anim.Play("Idle");
            }
            targetVelocity = new Vector2(0, 0);
            return;
        }

        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        targetVelocity = new Vector2(moveDirection.x * maxSpeed, 0);

        if (targetVelocity.x < -.01)
        {
            transform.localScale = new Vector2(-2f, 2f);
        }
        else if (targetVelocity.x > .01)
        {
            transform.localScale = new Vector2(2f, 2f);
        }

        anim.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
    }
    private IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(1f);
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}
