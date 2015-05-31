using UnityEngine;

public class Machinegun : Weapon {

    protected void Awake() {
        projectilePrefab = Resources.Load<GameObject>("Projectiles/Bullet");
        armSprite = Resources.Load<Sprite>("Weapons/Machine Gun");
        fireRate = 0.1f;
        projectileStartYOffset = 1.4f;
        projectileStartMovement = 1.55f;
    }
}