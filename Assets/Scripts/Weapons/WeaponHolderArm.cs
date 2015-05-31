using UnityEngine;
using System.Collections;

public class WeaponHolderArm : MonoBehaviour {
    public CharacterMotor motor;

    private SpriteRenderer r;
    private Sprite defaultSprite;
    private Transform armRoot;
    private bool awoken = false;

	void Awake()
    {
        if(awoken) return;

        awoken = true;
        r = GetComponent<SpriteRenderer>();
        defaultSprite = r.sprite;
        armRoot = transform.parent;
	}
	
	public Sprite sprite
    {
        get
        {
            return r.sprite;
        }
        set
        {
            if(!r) Awake();
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
            if (target != null) {
                var direction = target - transform.position;
                direction.x = Mathf.Abs(direction.x);
                armRoot.rotation = Quaternion.LookRotation(Vector3.forward, direction)*Quaternion.Euler(0, 0, 180);
            }
        }
    }

    public void ResetArm()
    {
        r.sprite = defaultSprite;
    }
}
