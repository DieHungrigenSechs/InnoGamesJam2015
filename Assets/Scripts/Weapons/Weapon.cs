using UnityEngine;

public abstract class Weapon : MonoBehaviour {
    private const float ProjectileStartXOffset = 0.75f;
    private const float ProjectileStartYOffset = 1f;
    private const float ProjectileInitialSpeed = 13f;

    private float lastShot;

    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    protected float fireRate = 0.5f;

    private CharacterMotor characterMotor;

    protected void Awake() {
        characterMotor = GetComponent<CharacterMotor>();
    }

    public void Attack() {
        if (Time.timeSinceLevelLoad - lastShot < fireRate) {
            return;
        }
        lastShot = Time.timeSinceLevelLoad;

        Vector3 spawnPosition = transform.position;
        bool isTurnedToRight = true;
        if (characterMotor != null)
        {
            isTurnedToRight = characterMotor.IsTurnedToRight;
        }
        if (isTurnedToRight) {
            spawnPosition += new Vector3(ProjectileStartXOffset, ProjectileStartYOffset, 0f);
        } else {
            spawnPosition += new Vector3(-ProjectileStartXOffset, ProjectileStartYOffset, 0f);
        }
            
        GameObject shot = Instantiate(projectilePrefab, spawnPosition, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        Rigidbody2D rigidbodyComponent = shot.GetComponent<Rigidbody2D>();
        if (rigidbodyComponent != null) {
            if (isTurnedToRight)
            {
                rigidbodyComponent.AddForce(new Vector2(ProjectileInitialSpeed, 0), ForceMode2D.Impulse);
            }
            else
            {
                rigidbodyComponent.AddForce(new Vector2(-ProjectileInitialSpeed, Random.Range(-1f,1f) * ProjectileInitialSpeed), ForceMode2D.Impulse);
            }
        }
    }

}

