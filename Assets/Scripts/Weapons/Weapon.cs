using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    protected float projectileStartMovement = 1f;

    protected float projectileStartYOffset = 1f;

    protected float projectileInitialSpeed = 13f;

    private float lastShot;

    protected float fireRate = 0.5f;

    protected GameObject projectilePrefab;
    protected Sprite armSprite;

    private CharacterMotor characterMotor;

    private bool isNPC;

    void OnEnable()
    {
        if (armSprite != null) {
            GetComponentInChildren<WeaponHolderArm>().sprite = armSprite;
        }
        isNPC = (!GetComponent<CharacterInput>());
        characterMotor = GetComponent<CharacterMotor>();
    }

    public void Attack() {
        if (Time.timeSinceLevelLoad - lastShot < fireRate) {
            return;
        }
        lastShot = Time.timeSinceLevelLoad;

        // Player attack (shoot to mouse)
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        Vector3 spawnPosition = new Vector3(transform.position.x + direction.x * projectileStartYOffset, transform.position.y + projectileStartYOffset + direction.y * projectileStartYOffset, 0f);

        GameObject shot = Instantiate(projectilePrefab, spawnPosition, rotation) as GameObject;
        Rigidbody2D shotRigidbody = shot.GetComponent<Rigidbody2D>();
        if (shotRigidbody != null) {
            shotRigidbody.velocity = direction * projectileInitialSpeed;
        }
    }

}

