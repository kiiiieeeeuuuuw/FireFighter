﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public LayerMask WhatIsFire;
    public float Health = 100;
    private float TimeBetweenDamage;
    private bool DamageTaken;
    public float StartTimeBetweenDamage;
    public GameObject PlayerSprite;
    public List<GameObject> Glows;    
    private Rigidbody2D Rb;
    public float force;    

    public Color FullHealth;
    public Color Q3Health;
    public Color HalfHealth;
    public Color Q1Health;

    private TrailRenderer TR;

    public ParticleSystem Explosion;

    private void Start()
    {
        foreach (Transform t in PlayerSprite.transform)
        {
            if (t.name.ToLower().Contains("glow"))
                Glows.Add(t.gameObject);
        }

        Rb = GetComponent<Rigidbody2D>();
        TR = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (DamageTaken)
            TimeBetweenDamage -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Meteor"))
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Damage(25, collision.transform.position);
            collision.gameObject.GetComponent<DestroyMeteor>().DestroyMe();
        }
    }

    public void Damage(float dmg, Vector3 enemyPos)
    {
        if(TimeBetweenDamage <= 0) {
            if (Health > 0)
            {
                Health -= dmg;
                HandleColor();
            }

            var playerPos = GetComponent<Transform>().position;
            var direction = new Vector2(playerPos.x - enemyPos.x, 1).normalized;
            var vel = direction * force;
            Rb.velocity = vel;

            TimeBetweenDamage = StartTimeBetweenDamage;
        }
        else        
            DamageTaken = true;        
    }

    public void Heal(float healing)
    {        
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
        {
            glow.GetComponent<SpriteRenderer>().color = visibleColor;
        }
        TR.startColor = visibleColor;
    }
}
