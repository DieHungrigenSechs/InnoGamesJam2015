using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public GameObject explosion;

    private const float ExplosionRange = 10f;

    private const float ExplosionForce = -10f;

    protected void OnCollisionEnter2D(Collision2D collision) {
        Rigidbody2D rigidbodyComponent = GetComponent<Rigidbody2D>();
        if (rigidbodyComponent != null) {
            rigidbodyComponent.velocity = Vector2.zero;
        }
    }

    public void Awake() {
        StartCoroutine(Arm(3.0f));
    }

    public IEnumerator Arm(float timerInSeconds) {
        yield return new WaitForSeconds(timerInSeconds);
        Explode();
    }

    private void Explode() {
        // Apply force to all rigid bodies within circle
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), ExplosionRange);
        foreach (Collider2D collider in colliders) {
            Rigidbody2D affectedRigidbody = collider.attachedRigidbody;
            if (affectedRigidbody != null) {
                affectedRigidbody.AddForce((collider.transform.position - transform.position).normalized * ExplosionForce);
            }
        }

        Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
