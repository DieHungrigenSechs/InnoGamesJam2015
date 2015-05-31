using UnityEngine;
using System.Collections;

public class NPCHealth : MonoBehaviour 
{
	[SerializeField] private float lifeCounter = 100;
	
	public void SetEnergy(float value)
	{
		lifeCounter += lifeCounter;
		if(lifeCounter <= 0)
		{
			Destroy(gameObject);
		}
	}
	
	public float Energy
	{
		get
		{
			return lifeCounter;
		}
	}
}
