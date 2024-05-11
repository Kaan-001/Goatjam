using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Hareket
    public float moveSpeed = 4f;
    private Vector2 movement;
    private Rigidbody2D rb;

    //Dash Sistemi
    public float dashSpeed = 13f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                isDashing = false;
                movement = Vector2.zero;
            }
        }
        else
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.Space) && dashCooldownTimer <= 0)
            {
                StartCoroutine(Dash());
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (isDashing ? dashSpeed : moveSpeed) * Time.fixedDeltaTime);
    }

    IEnumerator Dash()
    {
        isDashing = true;
        dashTimer = dashDuration;
        dashCooldownTimer = dashCooldown;

        yield return null;
    }

}
