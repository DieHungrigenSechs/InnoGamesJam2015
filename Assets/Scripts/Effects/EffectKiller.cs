using UnityEngine;

public class EffectKiller : MonoBehaviour {
    private void Start() {
        Destroy(gameObject, GetComponent<ParticleSystem>().duration);
    }
}   