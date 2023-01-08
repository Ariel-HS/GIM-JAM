using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput; 
    Vector2 jumpInput;
    Rigidbody2D myRigidbody;
    CapsuleCollider2D capsuleCollider;

    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpPower = 15f;
    [SerializeField] private LayerMask platformLayer;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if(isGrounded())
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpPower);
            }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x*runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity; 
    }

    void FlipSprite()
    {
        if(moveInput.x > 0.01f)
            transform.localScale = Vector3.one;
        else if (moveInput.x < -0.01f)
            transform.localScale = new Vector3(-1,1,1);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, Vector2.down, 0.01f, platformLayer);
        return raycastHit.collider != null;
    }
}
