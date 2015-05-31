using UnityEngine;

class Killzone : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.GetComponent<CharacterInput>()) {
            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
            if (health) {
                health.SetEnergy(-100000000000);
            }
        }
    }

}
