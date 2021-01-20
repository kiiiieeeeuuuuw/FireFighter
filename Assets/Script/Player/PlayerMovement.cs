using System.Collections;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using static Assets.Script.General.KeyboardManager;

public class PlayerMovement : MonoBehaviour
{
    #region shared movement fields

    private Rigidbody2D PlayerRigidBody;
    private PlayerControl PlayerControls;
    private Animator PlayerAnimatorController;

    #endregion

    #region horizontal movement fields
    [Header("Horizontal movement")]
    public float MoveSpeed = 15f;
    public bool IsAttacking = false;
    public ParticleSystem WalkingDustEffect;
    public Transform WalkingDustEffectLocation;
    public float DustInterval;
    private float CurrentDustTimePassed;

    #endregion

    #region vertical movement fields

    [Header("Vertical Movement")]
    public bool IsGrounded = false;
    private bool wasGrounded;

    public float JumpForce = 10f;
    private bool jumpStart = false;
    private bool jumpStop = false;
    private bool jumped = false;
    public float JumpMultiplier = 1;
    public float MaxJumpMultiplier = 3;
    public float JumpIncrement = 0.1f;
    public float FallMultiplier = 1.03f;

    #endregion

    #region dash movement fields
    [Header("Dash Movement")]
    public float DashSpeed = 40f;
    public float InvincibleTime = 0.5f;
    public float DashUnavailableTime = 0.5f;

    public ParticleSystem LeftDashEffect;
    public ParticleSystem RightDashEffect;
    public Transform DashEffectPos;
    private float currentDashTime;
    private Collider2D playerColider;
    private Color dashColor;
    [SerializeField]private bool dashAvailable = true;

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

    private void Awake()
    {
        PlayerControls = new PlayerControl();
    }

    private void OnEnable()
    {
        PlayerControls.Enable();
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
    }

    private void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        PlayerAnimatorController = GetComponent<Animator>();
        playerColider = GetComponent<Collider2D>();

        startScale = new Vector2
        {
            x = transform.localScale.x,
            y = transform.localScale.y
        };
    }

    private void Update()
    {
        MoveHorizontal();
        HandleDash();

        Jump();
        WallGlide();
        Fall();

        PlayerAnimatorController.SetBool("IsJumping", !IsGrounded);
        if(wasGrounded == false && IsGrounded) AudioManagerScript.PlaySound("jumpLand");
        wasGrounded = IsGrounded;
    }

    private void MoveHorizontal()
    {
        Vector3 movement = new Vector3(PlayerControls.Azerty.Move.ReadValue<float>(), 0,0);
        if (movement.x != 0 && !IsAttacking && !IsTouchingFront)
        {
            // Move player
            transform.position += movement * Time.deltaTime * MoveSpeed;
            // Set animation
            PlayerAnimatorController.SetBool("IsRunning", true);
            // Handle dust effect
            if (CurrentDustTimePassed <= 0 && IsGrounded)
            {
                StartDustEffect();
                CurrentDustTimePassed = DustInterval;
            }
            else
                CurrentDustTimePassed -= Time.deltaTime;
        }
        else PlayerAnimatorController.SetBool("IsRunning", false);

        //change the player orientation
        if (Mathf.Abs(movement.x) > 0)
            transform.localScale = new Vector3(startScale.x * movement.x, startScale.y);
    }

    private void Jump()
    {
        // Start charging up jump
        if (PlayerControls.Azerty.Jump.ReadValue<float>() == 1 && IsGrounded) jumpStart = true;            
        // Finished charging jump
        if (jumpStart && PlayerControls.Azerty.Jump.ReadValue<float>() == 0) jumpStop = true;
        
        if(jumpStart)
        {            
            if (!jumpStop)
            {
                if (JumpMultiplier < MaxJumpMultiplier) JumpMultiplier += JumpIncrement;
            }
            else
            {
                // Move player
                PlayerAnimatorController.SetTrigger("TakeOff");
                AudioManagerScript.PlaySound("jumpLand");
                PlayerRigidBody.AddForce(new Vector2(0f, JumpForce * JumpMultiplier), ForceMode2D.Impulse);

                // Reset jump parameters
                JumpMultiplier = 1;
                jumpStart = false;
                jumpStop = false;
                jumped = true;
            }
        }
    }

    private void Fall()
    {
        // Increase fall speed over time
        if(!IsGrounded && PlayerRigidBody.velocity.y < 0)
        {
            SetVelocity(new Vector2(PlayerRigidBody.velocity.x, PlayerRigidBody.velocity.y*FallMultiplier), "fall");
        }
    }

    // Public because it's handled by the players health
    public void SetDashColor(Color color)
    {
        dashColor = color;
    }

    private void HandleDash()
    {
        var LeftDash = PlayerControls.Azerty.LeftDash.ReadValue<float>() == 1;
        var RightDash = PlayerControls.Azerty.RightDash.ReadValue<float>() == 1;
        
        if ((LeftDash || RightDash) && dashAvailable)
        {
            ParticleSystem DashEffect = new ParticleSystem();
            currentDashTime = 0.1f;
            PlayerAnimatorController.SetTrigger("Dash");            

            if (RightDash)
            {
                SetVelocity(Vector2.right * DashSpeed, "dashmoveright");
                DashEffect = RightDashEffect;
            }
            if (LeftDash)
            {
                SetVelocity(Vector2.left * DashSpeed, "dashmoveleft");
                DashEffect = LeftDashEffect;
            }
            DashEffect.startColor = dashColor;
            Instantiate(DashEffect, DashEffectPos.position, DashEffect.transform.rotation);
            playerColider.enabled = false;
            StartCoroutine(Dashing());
            AudioManagerScript.PlaySound("woosh");
            dashAvailable = false;
        }        

        // End dash
        currentDashTime -= Time.deltaTime;
        if (currentDashTime <= 0)
        {
            SetVelocity(new Vector2(0f, PlayerRigidBody.velocity.y), "handledash");
            StartCoroutine(EnableDash());
        }
    }

    void WallGlide()
    {         
        IsTouchingFront = Physics2D.OverlapCircleAll(FrontalCheck.position, CheckRadius).Any(x => x.CompareTag("Wall"));
        //var move = Input.GetAxisRaw("Horizontal");
        var move = PlayerControls.Azerty.Move.ReadValue<float>();
        bool WallSliding = IsTouchingFront && !IsGrounded && move != 0;
        PlayerAnimatorController.SetBool("IsWallHugging", WallSliding);
        if(WallSliding)        
            PlayerRigidBody.velocity = new Vector2(0, Mathf.Clamp(PlayerRigidBody.velocity.y, -WallSlidingSpeed, float.MaxValue));        

        if (PlayerControls.Azerty.Jump.ReadValue<float>() == 1 && WallSliding)
        {
            WallJumping = true;
            Invoke("EndWallJump", WallJumpTime);
        }

        if (WallJumping)        
            SetVelocity(new Vector2(xWallForce * -move, yWallForce), "walljump");        
    }

    void EndWallJump()
    {
        WallJumping = false; 
        SetVelocity(new Vector2(0f, PlayerRigidBody.velocity.y), "EndWallJump");
    }

    void SetVelocity(Vector2 velocity, string origin)
    {
        PlayerRigidBody.velocity = velocity;
        Debug.Log(origin);
    }

    IEnumerator Dashing()
    {
        yield return new WaitForSeconds(InvincibleTime);
        playerColider.enabled = true;
    }

    IEnumerator EnableDash()
    {
        yield return new WaitForSeconds(DashUnavailableTime);
        dashAvailable = true;
    }

    public void StartDustEffect()
    {
        if (!jumped)
            Instantiate(WalkingDustEffect, WalkingDustEffectLocation.position, quaternion.identity);
        else
        {
            jumped = false;
            CurrentDustTimePassed = DustInterval;
        }
    }
}
