using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	delegate void DeadPlayerDelegate();
	DeadPlayerDelegate deadPlayer;
	[SerializeField] private int lifeCounter = 100;

	public void SetEnergy(int value)
	{
		lifeCounter += lifeCounter;
		if(lifeCounter <= 0)
		{
			deadPlayer.Invoke();
		}
	}

	public int Energy
	{
		get
		{
			return lifeCounter;
		}
	}
}
