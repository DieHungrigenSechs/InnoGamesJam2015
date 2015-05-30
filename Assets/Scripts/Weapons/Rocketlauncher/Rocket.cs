using UnityEngine;

public class Rocket:Projectiles 
{
    public GameObject explosion;

    private Rigidbody2D rocketRigidbody;

    protected void OnEnable() {
        rocketRigidbody = GetComponent<Rigidbody2D>();
    }

    protected void Update() {
        //transform.rotation = Quaternion.SetLookRotation(rocketRigidbody.velocity);
        //transform.rotation.SetLookRotation(rocketRigidbody.velocity);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        var target = rocketRigidbody.velocity;
        var direction = target - new Vector2(transform.position.x, transform.position.y);
        direction.x = Mathf.Abs(direction.x);
        transform.localRotation = Quaternion.LookRotation(Vector3.forward, direction) * Quaternion.Euler(0, 0, 180);
    } 

    protected void OnCollisionEnter2D(Collision2D collision) {
        Instantiate(explosion, transform.position, Quaternion.identity);
        base.OnCollisionEnter2D(collision);
    }
}

