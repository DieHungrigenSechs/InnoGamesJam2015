using UnityEngine;

public class Bombthrower : Weapon {
    protected void Awake() {
        projectilePrefab = Resources.Load<GameObject>("Projectiles/Bomb");
    }
}