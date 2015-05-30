using UnityEngine;

public class Rocket:MonoBehaviour {

    protected void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }

}

