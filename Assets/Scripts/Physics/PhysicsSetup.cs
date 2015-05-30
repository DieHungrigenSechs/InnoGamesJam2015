using UnityEngine;

class PhysicsSetup : MonoBehaviour {

    Vector2 Gravity = new Vector2(0, -15f);

    public void Awake() {
        Physics2D.gravity = Gravity;
        Physics2D.raycastsStartInColliders = false;
    }

}

