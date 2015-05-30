using UnityEngine;
using System.Collections;

public class WeaponHolderArm : MonoBehaviour
{
    private SpriteRenderer r;
    private Sprite defaultSprite;
    private Transform armRoot;
    private CharacterMotor motor;

	void Awake()
    {
        r = GetComponent<SpriteRenderer>();
        defaultSprite = r.sprite;
        armRoot = transform.parent;
        motor = transform.root.GetComponent<CharacterMotor>();
	}
	
	public Sprite sprite
    {
        get
        {
            return r.sprite;
        }
        set
        {
            r.sprite = value;
        }
    }
    
    void LateUpdate()
    {
        var weaponEquipped = r.sprite != defaultSprite;

        if (weaponEquipped)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -90);
            var target = motor.GetTargetPosition();
            var direction = target - transform.position;
            direction.x = Mathf.Abs(direction.x);
            armRoot.localRotation = Quaternion.LookRotation(Vector3.forward, direction) * Quaternion.Euler(0, 0, 180);
        }
    }

    public void ResetArm()
    {
        r.sprite = defaultSprite;
    }
}
