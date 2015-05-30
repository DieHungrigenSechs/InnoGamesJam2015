using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	static GameController Instance { get; set; }
	
	void Singleton()
	{
		//Check if there are any other instances
		if(Instance != null && Instance != this)
		{
			//Destroy other instances
			Destroy(gameObject);
		}
		
		//Singleton instance
		Instance = this;
	}
	
	void Awake()
	{
		Singleton();
		DontDestroyOnLoad(gameObject);
	}
}