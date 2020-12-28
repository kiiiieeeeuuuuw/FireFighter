using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Parameters")]
    public float StartTimeBtwAttack;
    public float MaxPassedTime;
    public LayerMask WhatIsFire;
    public float AttackRange;
    public float KnockBackForce;
    public float BounceForce;
    public float AnimationLength;

    [Header("Attack positions")]
    public Transform ForwardAttackPos;
    public Transform UpAttackPos;
    public Transform DownAttackPos;

    [Header("KeyBindings")]
    public KeyCode AttackCode = KeyCode.J;
    public KeyCode UpCode = KeyCode.Z;
    public KeyCode DownCode = KeyCode.S;

    [Header("Camera FX")]
    public GameObject CinemachineCamera;

    [Header("Scorekeeper")]
    public GameObject SKObject;
    public int MeteorScore;
    public int FlameScore;     

    private float TimeBtwAttack;    
    private float PassedTime;
    private bool FirstAttackPassed = false;
    private bool FirstUpAttackPassed = false;        
    private bool BounceOnDownAttack;
    private ScoreKeeper SK;

    private Animator PlayerAC;
    private Rigidbody2D RB;
    private PlayerMovement PM;
    private Transform PlayerScale;

    private void Start()
    {
        PlayerAC = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        PM = GetComponent<PlayerMovement>();
        PlayerScale = GetComponent<Transform>();
        SK = SKObject.GetComponent<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        // bugfix, otherwise animation will be triggered twice
        PlayerAC.ResetTrigger("DownAttack");

        Vector3 AttackPosToCheck;
        BounceOnDownAttack = false;
        if (TimeBtwAttack <= 0)
        {            
            if (Input.GetKey(AttackCode))   
            {
                CinemachineCamera.GetComponent<CameraShake>().StartCameraShake(0.1f);
                PM.isAttacking = true;
                StartCoroutine(Attacking());
                if (Input.GetKey(UpCode))
                {
                    AttackPosToCheck = UpAttackPos.position;
                    if (!FirstUpAttackPassed)
                    {
                        PlayerAC.SetTrigger("UpAttack1");
                        FirstUpAttackPassed = true;
                    }
                    else if (PassedTime < MaxPassedTime)
                    {
                        PassedTime = 0;
                        FirstUpAttackPassed = false;
                        PlayerAC.SetTrigger("UpAttack2");
                    }                    
                }
                else if (Input.GetKey(DownCode) && !PM.isGrounded)
                {
                    PlayerAC.SetTrigger("DownAttack");
                    AttackPosToCheck = DownAttackPos.position;
                    BounceOnDownAttack = true;
                }
                else
                {
                    RB.velocity = new Vector2(0, RB.velocity.y);
                    if (!FirstAttackPassed)
                    {
                        PlayerAC.SetTrigger("Attack1");
                        FirstAttackPassed = true;
                    }
                    else if (PassedTime < MaxPassedTime)
                    {
                        PassedTime = 0;
                        FirstAttackPassed = false;
                        PlayerAC.SetTrigger("Attack2");
                    }
                    AttackPosToCheck = ForwardAttackPos.position;

                    var xDir = PlayerScale.localScale.x > 0 ? 1 : -1;
                    RB.AddForce(new Vector2(xDir * KnockBackForce, 0), ForceMode2D.Impulse);
                }

                Collider2D[] flamesToDouse = Physics2D.OverlapCircleAll(AttackPosToCheck, AttackRange, WhatIsFire);   
                if(BounceOnDownAttack && flamesToDouse.Length > 0)
                {
                    RB.velocity = new Vector2(RB.velocity.x, BounceForce);
                    TimeBtwAttack = 0;
                }
                foreach(var flame in flamesToDouse)
                {
                    var ext = flame.GetComponent<ExtinguishFlame>();
                    if (flame.GetComponent<DestroyMeteor>() != null)
                    {
                        flame.GetComponent<DestroyMeteor>().DestroyByPlayer();
                        SK.IncreaseScore(MeteorScore);
                    }
                    else if (ext != null && !ext.Doused)
                    {
                        SK.IncreaseScore(FlameScore);
                        AudioManagerScript.PlaySound("extinguish");
                        ext.Extinguish();
                    }                     
                }
                TimeBtwAttack = StartTimeBtwAttack;                               
            }            
        }
        else
        {
            TimeBtwAttack -= Time.deltaTime;            
        }
        if(FirstAttackPassed || FirstUpAttackPassed)
            PassedTime += Time.deltaTime;
        if (PassedTime > MaxPassedTime)
        {
            PassedTime = 0;
            FirstAttackPassed = false;
            FirstUpAttackPassed = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(ForwardAttackPos.position, AttackRange);
        Gizmos.DrawSphere(UpAttackPos.position, AttackRange);
        Gizmos.DrawSphere(DownAttackPos.position, AttackRange);
    }

    IEnumerator Attacking()
    {
        yield return new WaitForSeconds(AnimationLength);
        PM.isAttacking = false;
    }
}
