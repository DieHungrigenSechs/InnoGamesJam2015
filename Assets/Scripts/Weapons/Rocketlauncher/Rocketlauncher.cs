using UnityEngine;

public class Rocketlauncher : Weapon {

    protected void Awake() {
        projectilePrefab = Resources.Load<GameObject>("Projectiles/Rocket");
    }

}
