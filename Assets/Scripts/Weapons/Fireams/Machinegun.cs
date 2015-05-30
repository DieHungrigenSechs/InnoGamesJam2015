using UnityEngine;

public class Machinegun : Weapon {

    protected void Awake() {
        projectilePrefab = Resources.Load<GameObject>("Projectiles/Bullet");
        fireRate = 0.1f;
    }
}