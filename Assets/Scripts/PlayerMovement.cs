using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private TalkingScript talkingScript;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveInput;
    private void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        moveInput = new Vector2(x, y).normalized;

        animator.SetBool("WalkingLeft", x < 0);
        animator.SetBool("WalkingRight", x > 0);
        animator.SetBool("WalkingUp", y > 0 && Mathf.Abs(y) >= Mathf.Abs(x));
        animator.SetBool("WalkingDown", y < 0 && Mathf.Abs(y) >= Mathf.Abs(x));

        

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x < 0)
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
                animator.SetBool("WalkingLeft", true);
            }
            else if (x > 0)
            { 
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetBool("WalkingRight", true);
            }
            
        }

        else
        {
            if (y > 0) animator.SetBool("WalkingUp", true);
            else if (y < 0) animator.SetBool("WalkingDown", true);
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);

        if (talkingScript.introTalking || talkingScript.paperIntro)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }

}
