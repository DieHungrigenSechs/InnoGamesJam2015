using UnityEngine;

public class GlitchGun : Weapon {

    protected void Awake() {
        projectilePrefab = Resources.Load<GameObject>("Projectiles/Glitch");
        Debug.Log("glitchPrefab: " + projectilePrefab);
        projectileStartYOffset = 1.2f;
        projectileStartMovement = 1.2f;
    }

}