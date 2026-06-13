using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Animator animator;

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(x, y).normalized;

        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;


        //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 direction = mousePosition - (Vector2)transform.position;

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, angle);

        animator.SetBool("WalkingLeft", false);
        animator.SetBool("WalkingRight", false);
        animator.SetBool("WalkingUp", false);
        animator.SetBool("WalkingDown", false);

        if (x == 0 && y == 0)
        {
            //danimator.SetBool("IdleSide", true);
        }

        else if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x < 0)
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
                animator.SetBool("WalkingLeft", true);
            }
            else
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

    
}
