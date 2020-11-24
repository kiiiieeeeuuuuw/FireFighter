﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth : MonoBehaviour
{
    [Header("Parameters")]    
    public GameObject PlayerSprite;
    public LayerMask WhatIsFire;
    public float Health = 100;    
    public float StartTimeBetweenDamage;          
    public float KnockBackForce;

    [Header("CameraEffects")]
    public GameObject CinemachineCamera;
    public GameObject PostProcessing;
    public float HitEffectDuration;
    
    [Header("Effects")]
    public ParticleSystem Explosion;
    public ParticleSystem HealingEffect;

    [Header("Damage color codes")]
    public Color FullHealth;
    public Color Q3Health;
    public Color HalfHealth;
    public Color Q1Health;

    [Header("UI reference")]
    public GameObject UI;

    private TrailRenderer TR;
    private List<GameObject> Glows;
    private Rigidbody2D RB;
    private float TimeBetweenDamage;
    private Animator PlayerAC;
    private PlayerMovement PM;
    private bool Death;

    private void Start()
    {
        Glows = new List<GameObject>();
        foreach (Transform t in PlayerSprite.transform)
        {
            if (t.name.ToLower().Contains("glow"))
                Glows.Add(t.gameObject);
        }

        RB = GetComponent<Rigidbody2D>();
        TR = GetComponent<TrailRenderer>();
        PlayerAC = GetComponent<Animator>();
        PM = GetComponent<PlayerMovement>();
        Death = false;
        HandleColor();
    }

    private void Update()
    {
        if (TimeBetweenDamage > 0)
            TimeBetweenDamage -= Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (Death)
        {
            PlayerAC.Play("PlayerDeath");
            PM.enabled = false;
            RB.velocity = new Vector2(0, 0);
            RB.isKinematic = true;
            UI.SetActive(true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Meteor"))
        {
            Instantiate(Explosion, transform.position, Quaternion.identity, transform);
            Damage(25, collision.transform.position);
            collision.gameObject.GetComponent<DestroyMeteor>().DestroyMe();
        }
    }

    public void Damage(float dmg, Vector3 enemyPos)
    {
        if(TimeBetweenDamage <= 0) {
            Health -= dmg;
            if (Health <= 0)
            {
                Death = true;
            }
            if (Health > 0)
            {                
                CinemachineCamera.GetComponent<CameraShake>().StartCameraShake();
                PostProcessing.GetComponent<PostProcessControl>().ShowVignetteEffect(true, false);
                PlayerAC.SetTrigger("Damage");
                HandleColor();                
            }            

            var playerPos = GetComponent<Transform>().position;
            var direction = new Vector2(playerPos.x - enemyPos.x, 1).normalized;
            var velocity = direction * KnockBackForce;
            RB.velocity = velocity;

            TimeBetweenDamage = StartTimeBetweenDamage;
        }               
    }

    public void Heal(float healing)
    {
        Instantiate(HealingEffect, transform.position, Quaternion.identity,transform);
        PostProcessing.GetComponent<PostProcessControl>().ShowVignetteEffect(false, true);
        Health += healing;
        if (Health > 100) Health = 100;
        HandleColor();
    }

    private void HandleColor()
    {
        Color visibleColor;
        switch (Health)
        {
            case 100:
                visibleColor = FullHealth;
                break;
            case 75:
                visibleColor = Q3Health;
                break;
            case 50:
                visibleColor = HalfHealth;
                break;
            case 25:
                visibleColor = Q1Health;
                break;
            default:
                visibleColor = Color.black;
                break;
        }

        foreach(var glow in Glows)        
            glow.GetComponent<SpriteRenderer>().color = visibleColor;
        
        TR.startColor = visibleColor;
        PM.SetDashColor(visibleColor);
    }    

    public void KillPlayer()
    {
        Death = true;
    }
}
