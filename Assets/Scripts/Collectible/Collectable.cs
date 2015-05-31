using UnityEngine;

public abstract class Collectable : MonoBehaviour {

    private float deSpawnTime = 20f;

    private float speed = 0.5f;

    private Rigidbody2D rigidbodyComponent;

    private float oldx = 0f;

    private float lastChange = 0f;

    protected void Start() {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        Destroy(gameObject, deSpawnTime);
    }

    protected void FixedUpdate() {
        rigidbodyComponent.AddForce(new Vector2(speed, 0f));
        if (transform.position.x == oldx && Mathf.Abs(Time.timeSinceLevelLoad - lastChange) > 0.5f) {
            speed = -speed;
            lastChange = Time.timeSinceLevelLoad;
        }
        oldx = transform.position.x;
    }

    protected void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.GetComponent<CharacterInput>()) {
            Destroy(this);
        }
    }
}
