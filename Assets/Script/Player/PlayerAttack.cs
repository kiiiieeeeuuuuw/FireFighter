using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float TimeBtwAttack;
    public float StartTimeBtwAttack;

    public float PassedTime;
    private bool FirstAttackPassed = false;
    public float MaxPassedTime;

    private KeyCode AttackCode = KeyCode.J;

    public Transform AttackPos;
    public LayerMask WhatIsFire;
    public float AttackRange;


    private Animator PlayerAC;
    private Rigidbody2D RB;
    private PlayerMovement PM;

    private void Start()
    {
        PlayerAC = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        PM = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeBtwAttack <= 0)
        {
            if (Input.GetKey(AttackCode) && PM.isGrounded)   
            {
                RB.velocity = new Vector2(0, RB.velocity.y);
                if (!FirstAttackPassed)
                {
                    PlayerAC.SetTrigger("Attack1");
                    FirstAttackPassed = true;
                }
                else if(PassedTime < MaxPassedTime)
                {
                    PassedTime = 0;
                    FirstAttackPassed = false;
                    PlayerAC.SetTrigger("Attack2");
                }

                Collider2D[] flamesToDouse = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, WhatIsFire);
                foreach(var flame in flamesToDouse)
                {
                    //to do
                }
                TimeBtwAttack = StartTimeBtwAttack;
                PM.isAttacking = false;
            }            
        }
        else
        {
            TimeBtwAttack -= Time.deltaTime;
            PassedTime += Time.deltaTime;
        }
        if (PassedTime > MaxPassedTime)
        {
            PassedTime = 0;
            FirstAttackPassed = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(AttackPos.position, AttackRange);
    }

    public void TestEvent()
    {

    }
}
