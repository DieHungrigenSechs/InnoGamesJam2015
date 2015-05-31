﻿using UnityEngine;

public class Rocket:Projectiles 
{
    public GameObject explosion;

    private Rigidbody2D rocketRigidbody;

    protected void OnEnable() {
        rocketRigidbody = GetComponent<Rigidbody2D>();
    }

    protected void OnCollisionEnter2D(Collision2D collision) {
        Instantiate(explosion, transform.position, Quaternion.identity);
        base.OnCollisionEnter2D(collision);
    }
}

