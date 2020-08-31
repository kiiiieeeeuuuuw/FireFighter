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

    private void Start()
    {
        PlayerAC = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeBtwAttack <= 0)
        {
            if (Input.GetKey(AttackCode))   
            {
                PlayerAC.SetTrigger("Attack");                
                Collider2D[] flamesToDouse = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, WhatIsFire);
                foreach(var flame in flamesToDouse)
                {
                    //to do
                }
            }
            TimeBtwAttack = StartTimeBtwAttack;
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
