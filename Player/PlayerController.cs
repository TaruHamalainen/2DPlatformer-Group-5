using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Layer Masks")]
    [SerializeField] private LayerMask groundLayer;

    [Header("Movement Variables")]
    [SerializeField] private float movementAccereration;
    public float maxMovementSpeed;
    [SerializeField] private float groundLinearDrag;
    private float horizontalDirection;
    private bool changingDirection => (rb.velocity.x > 0f && horizontalDirection < 0f) || (rb.velocity.x < 0f && horizontalDirection > 0f);

    [Header("Jump Variables")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float airLinearDrag;
    [SerializeField] private float fallMultiplier = 8f;
    [SerializeField] private float lowJumpFallMultiplier = 5f;
    [SerializeField] private int extraJumps = 1;
    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    [SerializeField] private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    private int extraJumpsValue;


    [Header("Ground Collision Variables")]
    [SerializeField] private float groundRaycastLength;
    [SerializeField] private bool isGrounded;
    [SerializeField] Transform groundCheck;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalDirection = GetInput().x;

        if (horizontalDirection != 0) transform.localScale = new Vector3(horizontalDirection, 1f, 1f);

        if (Input.GetButtonDown("Jump"))
            jumpBufferCounter = jumpBufferTime;
        else
            jumpBufferCounter -= Time.deltaTime;

        if ((jumpBufferCounter > 0 && (coyoteTimeCounter > 0 || extraJumpsValue > 0)))
        {
            Jump();
        }
        UpdateAnimations();

    }
    private void FixedUpdate()
    {
        CheckCollisions();
        MoveCharacter();
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            extraJumpsValue = extraJumps;
            ApplyGroundLinearDrag();
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
            ApplyAirLinearDrag();
            FallMultiplier();
        }

    }
    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    private void MoveCharacter()
    {
        rb.AddForce(new Vector2(horizontalDirection, 0f) * movementAccereration);

        if (Mathf.Abs(rb.velocity.x) > maxMovementSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxMovementSpeed, rb.velocity.y);
    }
    private void ApplyGroundLinearDrag()
    {
        if (Mathf.Abs(horizontalDirection) < 0.4f || changingDirection)
            rb.drag = groundLinearDrag;
        else
            rb.drag = 0f;
    }
    private void ApplyAirLinearDrag()
    {
        rb.drag = airLinearDrag;
    }
    private void Jump()
    {
        if (!isGrounded)
            extraJumpsValue--;

        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        coyoteTimeCounter = 0f;
        jumpBufferCounter = 0f;

    }
    private void FallMultiplier()
    {
        if (rb.velocity.y < 0)
            rb.gravityScale = fallMultiplier;
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.gravityScale = lowJumpFallMultiplier;
        else
            rb.gravityScale = 1f;

    }
    private void CheckCollisions()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundRaycastLength, groundLayer);
    }
    private void UpdateAnimations()
    {
        anim.SetBool("isMoving", horizontalDirection != 0);
        anim.SetBool("isGrounded", isGrounded);
    }
}
