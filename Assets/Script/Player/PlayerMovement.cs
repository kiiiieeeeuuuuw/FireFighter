using Assets.Script.General;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region shared movement fields

    private Rigidbody2D rb;
    private Animator PlayerAC;

    private Color yellow = new Color(255, 255, 0);
    private Color red = new Color(255, 0, 0);
    private Color blue = new Color(0, 0, 255);

    private Vector3 movement;

    #endregion

    #region horizontal movement fields
    [Header("Horizontal movement")]
    public float moveSpeed = 5f;

    public bool isAttacking = false;

    #endregion

    #region vertical movement fields

    [Header("Vertical Movement")]
    public float jumpForce = 5f;

    public bool isGrounded = false;

    private bool jumpStart = false;

    private bool jumpStop = false;

    public float jumpMultiplier = 1;

    public float maxJumpMultiplier = 3;

    public float jumpIncrement = 0.5f;

    #endregion

    #region dash movement fields
    [Header("Dash Movement")]
    public float dashSpeed;

    private float dashTime;    

    private DirectionEnum direction = DirectionEnum.None;
    private DirectionEnum prevDirection;

    #endregion

    #region wallglide
    [Header("Wallglide parameters")]
    public Transform FrontalCheck;
    public bool IsTouchingFront;
    public bool WallSliding;
    public float WallSlidingSpeed;
    public float CheckRadius = 0.1f;

    bool WallJumping;
    public float xWallForce;
    public float yWallForce;
    public float WallJumpTime;

    #endregion    


    private Vector2 startScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerAC = GetComponent<Animator>();

        startScale = new Vector2
        {
            x = transform.localScale.x,
            y = transform.localScale.y
        };        
    }

    private void Update()
    {
        var moveDirection = MoveHorizontal();
        direction = moveDirection.x > 0 ? DirectionEnum.Right : DirectionEnum.Left;
        HandleDash(direction);
        Jump();
        WallGlide();
        Fall();
        PlayerAC.SetBool("IsJumping", !isGrounded);
    }

    void FixedUpdate()
    {        
               
    }

    Vector3 MoveHorizontal()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        var currentDirection = movement.normalized.x > 0 ? DirectionEnum.Right : DirectionEnum.Left;
        if (movement.x != 0 && !isAttacking)
        {
            if (!IsTouchingFront)
                transform.position += movement * Time.deltaTime * moveSpeed;
            else if (currentDirection != prevDirection)
                transform.position += movement * Time.deltaTime * moveSpeed;
            PlayerAC.SetBool("IsRunning", true);
        }
        else
            PlayerAC.SetBool("IsRunning", false);

        prevDirection = currentDirection;
        //change the player orientation
        if (Mathf.Abs(movement.x) > 0)
            transform.localScale = new Vector3(startScale.x * movement.normalized.x, startScale.y);
        
        return movement.normalized;
    }

    void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            jumpStart = true;            
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumpStop = true;
        }
        if(jumpStart)
        {            
            if (!jumpStop)
            {
                if (jumpMultiplier < maxJumpMultiplier) jumpMultiplier += jumpIncrement;
            }
            else
            {
                PlayerAC.SetTrigger("TakeOff");
                rb.AddForce(new Vector2(0f, jumpForce * jumpMultiplier), ForceMode2D.Impulse);
                jumpMultiplier = 1;
                jumpStart = false;
                jumpStop = false;
            }
        }
    }

    void Fall()
    {
        if(!isGrounded && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*1.05f);
        }
    }

    void HandleDash(DirectionEnum dir)
    {
        // Initiate dash        
        if (Input.GetKeyDown(KeyCode.LeftShift))        
            DashMove(dir);                                

        // End dash
        dashTime -= Time.deltaTime;
        if (dashTime <= 0)        
            rb.velocity = new Vector2(0f, rb.velocity.y);                                
    }

    void DashMove(DirectionEnum direction)
    {
        dashTime = 0.1f;
        if(direction != DirectionEnum.None)
        {
            if (direction == DirectionEnum.Right) rb.velocity = Vector2.right * dashSpeed;
            if (direction == DirectionEnum.Left) rb.velocity = Vector2.left * dashSpeed;            
        }

        PlayerAC.SetTrigger("Dash");
    }

    void WallGlide()
    {         
        IsTouchingFront = Physics2D.OverlapCircleAll(FrontalCheck.position, CheckRadius).Any(x => x.CompareTag("Wall"));
        var move = Input.GetAxisRaw("Horizontal");
        bool WallSliding = IsTouchingFront && !isGrounded && move != 0;
        PlayerAC.SetBool("IsWallHugging", WallSliding);
        if(WallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -WallSlidingSpeed, float.MaxValue));
        }

        if(Input.GetButtonDown("Jump") && WallSliding)
        {
            WallJumping = true;
            Invoke("SetWallJumpingToFalse", WallJumpTime);
        }

        if (WallJumping)
        {
            rb.velocity = new Vector2(xWallForce * -move, yWallForce);
        }
    }

    void SetWallJumpingToFalse()
    {
        WallJumping = false;
    }

    void StartAttack()
    {
        isAttacking = true;
    }

    void EndAttack()
    {
        isAttacking = false;
    }
}
