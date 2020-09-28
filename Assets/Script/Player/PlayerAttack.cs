using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float TimeBtwAttack;
    public float StartTimeBtwAttack;

    public float PassedTime;
    public bool FirstAttackPassed = false;
    public bool FirstUpAttackPassed = false;
    public float MaxPassedTime;

    private KeyCode AttackCode = KeyCode.J;
    private KeyCode UpCode = KeyCode.Z;
    private KeyCode DownCode = KeyCode.S;


    public Transform ForwardAttackPos;
    public Transform UpAttackPos;
    public Transform DownAttackPos;
    public bool BounceOnDownAttack;
    public LayerMask WhatIsFire;
    public float AttackRange;
    public float xForce;
    public float bounceForce;


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
                if (Input.GetKey(UpCode))
                {
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
                    AttackPosToCheck = UpAttackPos.position;
                }
                if (Input.GetKey(DownCode) && !PM.isGrounded)
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
                    RB.AddForce(new Vector2(xDir * xForce, 0), ForceMode2D.Impulse);
                }

                Collider2D[] flamesToDouse = Physics2D.OverlapCircleAll(AttackPosToCheck, AttackRange, WhatIsFire);   
                if(BounceOnDownAttack && flamesToDouse.Length > 0)
                {
                    RB.velocity = new Vector2(RB.velocity.x, bounceForce);
                    TimeBtwAttack = 0;
                }
                foreach(var flame in flamesToDouse)
                {
                    if (flame.GetComponent<DestroyMeteor>() != null)
                    {
                        flame.GetComponent<DestroyMeteor>().DestroyByPlayer();
                        GetComponent<PlayerHealth>().Heal(50);
                    }
                    flame.GetComponent<ExtinguishFlame>()?.Extinguish();
                }
                TimeBtwAttack = StartTimeBtwAttack;
                PM.isAttacking = false;                
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

    public void TestEvent()
    {

    }
}
