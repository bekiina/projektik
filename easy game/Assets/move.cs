using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    private Animator _animator;

    private float horizontal;
    private float speed = 8f;
    private float jumpPower = 12f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private string Scene;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.3f);
        }

        _animator.SetBool("IsInAir", !IsGrounded());
        _animator.SetBool("IsWalking", Input.GetAxis("Horizontal") != 0);



    }



    private void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
        

    private void Flip()
    {
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            transform.Rotate(0, 180, 0);
        }

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}