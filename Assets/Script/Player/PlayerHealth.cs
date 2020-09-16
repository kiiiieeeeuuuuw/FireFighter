using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public LayerMask WhatIsFire;
    public float Health = 100;
    public GameObject PlayerSprite;
    public List<GameObject> Glows;
    private Rigidbody2D Rb;
    public float force;    

    public Color FullHealth;
    public Color Q3Health;
    public Color HalfHealth;
    public Color Q1Health;

    private void Start()
    {
        foreach(Transform t in PlayerSprite.transform)
        {
            if (t.name.ToLower().Contains("glow"))
                Glows.Add(t.gameObject);
        }

        Rb = GetComponent<Rigidbody2D>();        
    }

    public void Damage(float dmg, Vector3 enemyPos)
    {
        Health -= dmg;
        HandleColor();

        var playerPos = GetComponent<Transform>().position;
        var direction = new Vector2(playerPos.x - enemyPos.x, 1).normalized;
        var vel = direction * force;
        Rb.velocity = vel;                       
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
    }
}
