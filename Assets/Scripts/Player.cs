using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2d;
    private Vector2 movement;
    
   
    private float horizontal; 
    private bool isFacingRight = true;
    private bool isJumping = false;
    private bool isFalling = false;
    private bool isRunning = false;
    private bool isGrounded= false;
    private bool isAttacking= false;

    public float moveSpeed = 8f;
    public float jumpingPower= 16f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private ParticleSystem dust;
    [SerializeField] private ParticleSystem grass;
    

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGroundedCheck() && !isJumping){
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpingPower);
            isJumping = true;
            isRunning = false;
        }

        if (Input.GetKeyDown(KeyCode.X)){
            Attack();
        }
    }

    void FixedUpdate() {
        rb2d.velocity = new Vector2(horizontal * moveSpeed, rb2d.velocity.y);
        
        if (rb2d.velocity.x > 0 || rb2d.velocity.x < 0 && !isJumping){
            isRunning = true;
        }else{
            isRunning = false;
        }

        if (rb2d.velocity.y < 0){
            isFalling = true;
            isJumping = false;
        }else if(rb2d.velocity.y > 0){
            isFalling = false;
            isJumping = true;            
        }

        if(isGroundedCheck()){     
            isJumping = false;
            isFalling = false;
            isGrounded = true;
        }else{
            isGrounded = false;
        }

        UpdateAnimator();
        Flip();
    }

    private void Flip(){
        float xDisplace = 0.9f;

        if (isFacingRight){
            xDisplace *= -1;
        }

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            Vector2 localPosition = transform.position;
            
            localScale.x *= -1f;
            transform.localScale = localScale;

            rb2d.position = new Vector2(localPosition.x + xDisplace, localPosition.y);
        }
    }

    private bool isGroundedCheck(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Attack(){
        if(!isAttacking){
            isAttacking = true;
            animator.ResetTrigger("attack");
            animator.SetTrigger("attack");
            isAttacking = false;
        }
    }

    private void UpdateAnimator(){
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isFalling", isFalling);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isGrounded", isGrounded);
    }

    public void PlayDustAnimation(){
        grass.Play();
    }
    
}
