using UnityEngine;

public class HealthCollectable : Collectable {

    protected void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.GetComponent<CharacterInput>()) {
		    PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
		    if(health)
		    {
                Debug.Log("HEALTH");
			    health.SetEnergy(50);
                Destroy(gameObject);
		    }
        }
    }

}