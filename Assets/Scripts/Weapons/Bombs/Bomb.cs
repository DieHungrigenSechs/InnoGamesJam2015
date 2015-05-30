using UnityEngine;

public class Bomb : MonoBehaviour {

    protected void OnCollisionEnter2D(Collision2D collision) {
        Rigidbody2D rigidbodyComponent = GetComponent<Rigidbody2D>();
        if (rigidbodyComponent != null) {
            rigidbodyComponent.isKinematic = true;
        }
    }       
}
