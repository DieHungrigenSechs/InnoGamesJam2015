using UnityEngine;
using System.Collections;

public class WeaponHolderArm : MonoBehaviour
{
    private SpriteRenderer r;
    private Sprite defaultSprite;
    private Transform armRoot;

	void Awake()
    {
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
            r.sprite = value;
        }
    }
    
    void LateUpdate()
    {
        if(r.sprite != defaultSprite)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
    }

    public void ResetArm()
    {
        r.sprite = defaultSprite;
    }
}
