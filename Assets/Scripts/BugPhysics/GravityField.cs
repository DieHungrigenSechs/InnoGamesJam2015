using UnityEngine;

public class GravityField : BugPhysics {

    [SerializeField]
    private float radius = 3f;

    [SerializeField] 
    private float force = -10f;

    [SerializeField]
    private float dampingStart = 0.75f;

    protected void Start() {
    }

    protected void FixedUpdate() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), radius);
        foreach (Collider2D collider in colliders) {
            Rigidbody2D affectedRigidbody = collider.attachedRigidbody;
            if (affectedRigidbody != null) {
                Debug.Log("Affecting rigid body " + affectedRigidbody);
                float forceMultiplier = Mathf.Clamp01((Vector3.Distance(collider.transform.position, transform.position) + (radius * dampingStart)) / radius);
                affectedRigidbody.AddForce((collider.transform.position - transform.position).normalized * force * forceMultiplier);
            }
        }
    }

    protected void OnDrawGizmosSelected() {
        UnityEditor.Handles.color = Color.magenta;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.zero, radius);
    }

}