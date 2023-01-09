using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput; 
    Vector2 jumpInput;
    Rigidbody2D myRigidbody;
    BoxCollider2D boxCollider;
    Animator anim;

    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpPower = 15f;
    [SerializeField] private LayerMask platformLayer;

    public float knockbackVelocity = 5f;
    public float knockbackTimer;
<<<<<<< Updated upstream
    public float knockbackDuration;
=======
    public float knockbackDuration = .2f;
>>>>>>> Stashed changes
    public bool knockedFromRight;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();

        anim.SetBool("isRunning", moveInput.x != 0);
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
        if(knockbackTimer <= 0)
        {
<<<<<<< Updated upstream
            Vector2 playerVelocity = new Vector2(moveInput.x*runSpeed, myRigidbody.velocity.y);
=======
            Vector2 playerVelocity = new Vector2 (moveInput.x*runSpeed, myRigidbody.velocity.y);
>>>>>>> Stashed changes
            myRigidbody.velocity = playerVelocity; 
        }
        else
        {
            if(knockedFromRight)
<<<<<<< Updated upstream
            {  
                Vector2 playerVelocity = new Vector2(-knockbackVelocity, knockbackVelocity);
=======
            {
                Vector2 playerVelocity = new Vector2 (-knockbackVelocity, knockbackVelocity);
>>>>>>> Stashed changes
                myRigidbody.velocity = playerVelocity; 
            }
            else
            {
<<<<<<< Updated upstream
                Vector2 playerVelocity = new Vector2(knockbackVelocity, knockbackVelocity);
                myRigidbody.velocity = playerVelocity; 
=======
                Vector2 playerVelocity = new Vector2 (knockbackVelocity, knockbackVelocity);
                myRigidbody.velocity = playerVelocity;                 
>>>>>>> Stashed changes
            }

            knockbackTimer -= Time.deltaTime;
        }
    }

    void FlipSprite()
    {
        if(moveInput.x > 0.01f)
            transform.localScale = Vector3.one;
        else if (moveInput.x < -0.01f)
            transform.localScale = new Vector3(-1,1,1);
    }

    private bool isGrounded()/// cek apakah di bawah ada ground/platform
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, platformLayer);
        return raycastHit.collider != null;
    }
}
