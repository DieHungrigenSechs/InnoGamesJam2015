using UnityEngine;
using System.Collections;

public class ObjectSpawn : MonoBehaviour 
{
	[SerializeField] GameObject spawnObject;
	[SerializeField] float durationForNext;
	[SerializeField] bool randomTime;
	[SerializeField] int maxCount = 1;
	
	[SerializeField] bool canSpawn = true;
	GameObject currentObject;

	// Use this for initialization
	IEnumerator Start () 
	{
		while (canSpawn)
		{
			yield return new WaitForSeconds(GetTimer());
			GameObject spawn = Instantiate(spawnObject,transform.position,Quaternion.identity) as GameObject;
			spawn.transform.SetParent(transform);

			if(transform.childCount > maxCount)
			{
				Destroy(transform.GetChild(0).gameObject);
			}
		}

	}

	private float GetTimer()
	{
		float time = durationForNext;
		if(randomTime)
		{
			time = Random.Range(0,durationForNext);
		}
		return time;
	}
}
