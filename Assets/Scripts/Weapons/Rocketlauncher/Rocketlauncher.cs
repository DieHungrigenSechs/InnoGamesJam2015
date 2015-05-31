using UnityEngine;

public class Rocketlauncher : Weapon {

    protected void Awake() {
        projectilePrefab = Resources.Load<GameObject>("Projectiles/Rocket");
        armSprite = Resources.Load<Sprite>("Weapons/Launcher");
        projectileStartYOffset = 1.4f;
    }

}
