using UnityEngine;

public class GravityField : BugPhysics {

    [SerializeField]
    private float radius = 3f;

    [SerializeField] 
    private float force = -10f;

    [SerializeField]
    private float dampingStart = 0.75f;

    private Vector3 initialSize;

    protected void Awake() {
        initialSize = transform.localScale;
    }

    protected void FixedUpdate() {
        // Apply force to all rigid bodies within circle
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), radius);
        foreach (Collider2D collider in colliders) {
            Rigidbody2D affectedRigidbody = collider.attachedRigidbody;
            if (affectedRigidbody != null) {
                float forceMultiplier = Mathf.Clamp01((Vector3.Distance(collider.transform.position, transform.position) + (radius * dampingStart)) / radius);
                affectedRigidbody.AddForce((collider.transform.position - transform.position).normalized * force * forceMultiplier);
            }
        }
    }

    protected void Update() {
        // Animation
        float change = Mathf.Sin(Time.time * 10f) * 0.5f;
        transform.localScale = new Vector3(initialSize.x + initialSize.x * change, initialSize.y + initialSize.y * change, 1f);
        transform.Rotate(Vector3.forward * Time.deltaTime * 200f);
    }

    protected override void Reset() {
        base.Reset();
        Destroy(gameObject);
    }
}