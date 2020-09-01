using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float TimeBtwAttack;
    public float StartTimeBtwAttack;

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
                PM.isAttacking = true;
                PlayerAC.SetTrigger("Attack");                                  

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
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(AttackPos.position, AttackRange);
    }
}
