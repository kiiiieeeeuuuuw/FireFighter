using Assets.Script.General;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
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
    public ParticleSystem DustEffect;
    public Transform DustEffectLocation;
    public float DustInterval;
    private float CurrentDustTimePassed;

    #endregion

    #region vertical movement fields

    [Header("Vertical Movement")]
    public float jumpForce = 5f;

    public bool isGrounded = false;
    private bool jumpStart = false;
    private bool jumpStop = false;
    private bool jumped = false;
    public float jumpMultiplier = 1;
    public float maxJumpMultiplier = 3;
    public float jumpIncrement = 0.5f;
    public float FallMultiplier;    

    #endregion

    #region dash movement fields
    [Header("Dash Movement")]
    public float dashSpeed;
    public float InvincibleTime;
    public ParticleSystem LeftDashEffect;
    public ParticleSystem RightDashEffect;
    public Transform DashEffectPos;

    private float currentDashTime;
    private bool dashStopped;
    private DirectionEnum direction = DirectionEnum.None;
    private DirectionEnum prevDirection;
    private Collider2D PlayerColider;
    private Color DashColor;

    #endregion

    #region wallglide
    [Header("Wallglide parameters")]
    public Transform FrontalCheck;
    public bool IsTouchingFront;
    public bool WallSliding;
    public float WallSlidingSpeed;
    public float CheckRadius = 0.1f;

    public bool WallJumping;
    public float xWallForce;
    public float yWallForce;
    public float WallJumpTime;

    #endregion    


    private Vector2 startScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerAC = GetComponent<Animator>();
        PlayerColider = GetComponent<Collider2D>();

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
        if(Input.GetAxis("Horizontal") != 0)
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
            if (CurrentDustTimePassed <= 0 && isGrounded)
            {
                StartDustEffect();
                CurrentDustTimePassed = DustInterval;
            }
            else
                CurrentDustTimePassed -= Time.deltaTime;
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
                jumped = true;
            }
        }
    }

    void Fall()
    {
        if(!isGrounded && rb.velocity.y < 0)
        {
            SetVelocity(new Vector2(rb.velocity.x, rb.velocity.y*FallMultiplier), "fall");
        }
    }

    public void SetDashColor(Color color)
    {
        DashColor = color;
    }

    void HandleDash(DirectionEnum dir)
    {
        // Initiate dash        
        if (Input.GetKeyDown(KeyCode.LeftShift))        
            DashMove(dir);                                

        // End dash
        currentDashTime -= Time.deltaTime;
        if (currentDashTime <= 0 && !dashStopped)
        {
            SetVelocity(new Vector2(0f, rb.velocity.y), "handledash");
            dashStopped = true;            
        }
    }

    void DashMove(DirectionEnum direction)
    {
        ParticleSystem DashEffect = new ParticleSystem();
        currentDashTime = 0.1f;
        if(direction != DirectionEnum.None)
        {
            if (direction == DirectionEnum.Right)
            {
                SetVelocity(Vector2.right * dashSpeed, "dashmoveright");
                DashEffect = RightDashEffect;
            }
            if (direction == DirectionEnum.Left)
            {
                SetVelocity(Vector2.left * dashSpeed, "dashmoveleft");
                DashEffect = LeftDashEffect;
            }
            dashStopped = false;
            PlayerColider.enabled = false;
            StartCoroutine(Dashing());
        }

        PlayerAC.SetTrigger("Dash");
        DashEffect.startColor = DashColor;
        Instantiate(DashEffect, DashEffectPos.position, DashEffect.transform.rotation);
    }

    void WallGlide()
    {         
        IsTouchingFront = Physics2D.OverlapCircleAll(FrontalCheck.position, CheckRadius).Any(x => x.CompareTag("Wall"));
        var move = Input.GetAxisRaw("Horizontal");
        bool WallSliding = IsTouchingFront && !isGrounded && move != 0;
        PlayerAC.SetBool("IsWallHugging", WallSliding);
        if(WallSliding)
        {
            rb.velocity = new Vector2(0, Mathf.Clamp(rb.velocity.y, -WallSlidingSpeed, float.MaxValue));
        }

        if(Input.GetButtonDown("Jump") && WallSliding)
        {
            WallJumping = true;
            Invoke("EndWallJump", WallJumpTime);
        }

        if (WallJumping)
        {
            SetVelocity(new Vector2(xWallForce * -move, yWallForce), "walljump");
        }
    }

    void EndWallJump()
    {
        WallJumping = false; 
        SetVelocity(new Vector2(0f, rb.velocity.y), "EndWallJump");
    }

    void SetVelocity(Vector2 velocity, string origin)
    {
        rb.velocity = velocity;
        Debug.Log(origin);
    }

    IEnumerator Dashing()
    {
        yield return new WaitForSeconds(InvincibleTime);
        PlayerColider.enabled = true;
    }

    public void StartDustEffect()
    {
        if (!jumped)
            Instantiate(DustEffect, DustEffectLocation.position, quaternion.identity);
        else
        {
            jumped = false;
            CurrentDustTimePassed = DustInterval;
        }
    }
}
