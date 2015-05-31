using UnityEngine;

public class Glitch : MonoBehaviour {

    public Vector2 speed;

    protected void FixedUpdate() {
        transform.localPosition = new Vector3(transform.localPosition.x + speed.x, transform.localPosition.y + speed.y, 0);
    }

    protected void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }

}

