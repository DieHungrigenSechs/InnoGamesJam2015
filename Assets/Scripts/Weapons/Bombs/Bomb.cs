using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour {

    protected void OnCollisionEnter2D(Collision2D collision) {
        Rigidbody2D rigidbodyComponent = GetComponent<Rigidbody2D>();
        if (rigidbodyComponent != null) {
            rigidbodyComponent.isKinematic = true;
        }
    }

    public void Start() {
        StartCoroutine(Arm(5.0f));
    }

    public IEnumerator Arm(float timerInSeconds) {
         yield return new WaitForSeconds(timerInSeconds);
        Explode();
    }

    private void Explode() {
        Destroy(this);
    }
}
