using UnityEngine;

public class Rocket:Projectiles 
{
    public GameObject explosion;

    protected void OnCollisionEnter2D(Collision2D collision) {
        Instantiate(explosion, transform.position, Quaternion.identity);
        base.OnCollisionEnter2D(collision);
    }
}

