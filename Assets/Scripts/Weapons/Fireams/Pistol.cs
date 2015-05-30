using UnityEngine;

public class Pistol:Weapon {

    protected void Awake() {
        projectilePrefab = Resources.Load<GameObject>("Projectiles/Bullet");
    }

}
