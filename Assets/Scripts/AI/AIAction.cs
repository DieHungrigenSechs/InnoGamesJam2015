using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class AIAction : MonoBehaviour
{
	void Start()
    {
        var collider = GetComponent<Collider2D>();
        
        if(!collider.isTrigger)
        {
            Debug.LogError("Eine AIAction kann niemals ausgeführt werden, da sie keinen Trigger hat.");
        }
	}
}
