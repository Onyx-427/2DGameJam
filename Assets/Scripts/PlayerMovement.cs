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


        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (angle == 0)
        {
            Debug.Log("looking right");
        }
        if (angle == 90)
        {
            Debug.Log("looking up");
        }
        if (angle == 180)
        {
            Debug.Log("looking left");
        }
        if (angle == 270)
        {
            Debug.Log("looking down");
        }
    }

    
}
