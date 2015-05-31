using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	delegate void DeadPlayerDelegate();
	 DeadPlayerDelegate deadPlayer;
	[SerializeField] private float lifeCounter = 100;

	public void SetEnergy(float value)
	{
		lifeCounter += lifeCounter;
		if(lifeCounter <= 0)
		{
			deadPlayer.Invoke();
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
