using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	delegate void DeadPlayerDelegate();
	 DeadPlayerDelegate deadPlayer;
	[SerializeField] private float lifeCounter = 100;

	public void SetEnergy(float value)
	{
		lifeCounter += value;
		if(lifeCounter <= 0)
		{
			BasicMenu menu = GameObject.FindObjectOfType<BasicMenu>();
			if(menu)
			{
				menu.LoadLevel(LevelEnum.GameOver);
			}
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
