using Assets.Script.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region shared movement fields

    private Rigidbody2D rb;

    public SpriteRenderer sprite;

    private Color yellow = new Color(255, 255, 0);
    private Color red = new Color(255, 0, 0);
    private Color blue = new Color(0, 0, 255);

    public GameObject MainCamera;

    #endregion

    #region horizontal movement fields

    public float moveSpeed = 5f;

    #endregion

    #region vertical movement fields

    public float jumpForce = 5f;

    public bool isGrounded = false;

    private bool jumpStart = false;

    private bool jumpStop = false;

    public float jumpMultiplier = 1;

    public float maxJumpMultiplier = 3;

    public float jumpIncrement = 0.5f;

    #endregion

    #region dash movement fields

    public float dashSpeed;

    private float dashTime;    

    private DirectionEnum direction = DirectionEnum.None;

    #endregion

    #region wallglide

    public Transform FrontalCheck;
    public bool IsTouchingFront;
    public float CheckRadius;    

    #endregion    
    private Vector2 startScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();        

        startScale = new Vector2
        {
            x = transform.localScale.x,
            y = transform.localScale.y
        };
    }

    void Update()
    {
        var moveDirection = MoveHorizontal();
        DirectionEnum direction = moveDirection.x > 0 ? DirectionEnum.Right : DirectionEnum.Left;
        HandleDash(direction);
        Jump();
        WallGlide();
        Fall();        
    }

    Vector3 MoveHorizontal()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        //change the player orientation
        if(Mathf.Abs(movement.x) > 0)
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
                if(sprite.color != red)
                {
                    float g = sprite.color.g;
                    g = g - 255 * jumpIncrement < 0 ? 0 : g - 255 * jumpIncrement;
                    sprite.color = new Color(sprite.color.r, g, sprite.color.b);
                }
            }
            else
            {
                rb.AddForce(new Vector2(0f, jumpForce * jumpMultiplier), ForceMode2D.Impulse);
                jumpMultiplier = 1;
                jumpStart = false;
                jumpStop = false;
                sprite.color = yellow;
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
    }

    void WallGlide()
    {
        IsTouchingFront = Physics2D.OverlapCircle(FrontalCheck.position, CheckRadius, 7);
        if (IsTouchingFront)
        {
            int a = 0;
        }
    }
}
