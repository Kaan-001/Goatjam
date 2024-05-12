using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    //Hareket
    public ParticleSystem particle;
    public float moveSpeed = 4f;
    private Vector2 movement;
    private Rigidbody2D rb;

    //Dash Sistemi
    public static int ScoreC=0;
    public float dashSpeed = 13f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;
    public Animator animator;
    public Text text;

    void Start()
    {
        this.transform.DOScale(1.2f,0.5f).SetLoops(-1,LoopType.Yoyo);
        animator=GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
         if(text!=null) text.text = PlayerMovement.ScoreC+"/30";
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
            if(movement.x!=0||movement.y!=0 ){particle.Play(); animator.Play("Run");}
            else if(movement.x==0||movement.y==0 ){animator.Play("idle");particle.Stop();}
            if(WeaponCont.neryebakiyor==0) this.gameObject.GetComponent<SpriteRenderer>().flipX=false;
            else if(WeaponCont.neryebakiyor==1) this.gameObject.GetComponent<SpriteRenderer>().flipX=true;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Furniture"))
        {
            SceneManager.LoadScene("Outro");
        }

    }

}
