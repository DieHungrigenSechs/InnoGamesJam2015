using UnityEngine;

public abstract class Weapon : MonoBehaviour {
    private const float ProjectileStartXOffset = 0.75f;
    private const float ProjectileStartYOffset = 1f;
    private const float ProjectileInitialSpeed = 13f;

    private float lastShot;

    protected float fireRate = 0.5f;

    protected GameObject projectilePrefab;
    protected Sprite armSprite;

    private CharacterMotor characterMotor;

    private bool isNPC;

    protected void Start() {
        isNPC = (!GetComponent<CharacterInput>());
        characterMotor = GetComponent<CharacterMotor>();
    }

    void OnEnable()
    {
        GetComponentInChildren<WeaponHolderArm>().sprite = armSprite;
    }

    public void Attack() {
        if (Time.timeSinceLevelLoad - lastShot < fireRate) {
            return;
        }
        lastShot = Time.timeSinceLevelLoad;

        //Vector3 spawnPosition = transform.position;
        Vector3 spawnPosition = transform.FindChild("Arm Right Higher").position;

        bool isTurnedToRight = true;
        if (characterMotor != null) {
            isTurnedToRight = characterMotor.IsTurnedToRight;
        }
        if (isTurnedToRight) {
            spawnPosition += new Vector3(ProjectileStartXOffset, ProjectileStartYOffset, 0f);
        } else {
            spawnPosition += new Vector3(-ProjectileStartXOffset, ProjectileStartYOffset, 0f);
        }
            
        GameObject shot = Instantiate(projectilePrefab, spawnPosition, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        Rigidbody2D shotRigidbody = shot.GetComponent<Rigidbody2D>();
        if (shotRigidbody != null) {
            if (isNPC) {
                // NPC simple attack based on direction
                if (isTurnedToRight) {
                    shotRigidbody.AddForce(new Vector2(ProjectileInitialSpeed, 0), ForceMode2D.Impulse);
                } else {
                    shotRigidbody.AddForce(
                        new Vector2(-ProjectileInitialSpeed, Random.Range(-1f, 1f)*ProjectileInitialSpeed),
                        ForceMode2D.Impulse);
                }
            } else {
                // Player attack (shoot to mouse)
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
                shotRigidbody.velocity = direction * ProjectileInitialSpeed;
            }
        }
    }

}

