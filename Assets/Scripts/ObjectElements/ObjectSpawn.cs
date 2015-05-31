using UnityEngine;
using System.Collections;

public class ObjectSpawn : MonoBehaviour 
{
	[SerializeField] GameObject spawnObject;
	[SerializeField] float durationForNext;
	[SerializeField] int amountSpawnIteration;
	[SerializeField] bool randomTime;
	[SerializeField] Vector3 offset;
	GameObject currentObject;
	// Use this for initialization
	IEnumerator Start () 
	{

		for(int i = 0; i < amountSpawnIteration; i++)
		{
			yield return new WaitForSeconds(GetTimer());
			SpawnObjectOnPlace();
		}
		while (amountSpawnIteration < 0)
		{
			yield return new WaitForSeconds(GetTimer());
			SpawnObjectOnPlace();
		}
	}

	void SpawnObjectOnPlace()
	{
		if(currentObject)
		{
			Destroy(currentObject);
		}
		currentObject = Instantiate(spawnObject,transform.position + offset,Quaternion.identity) as GameObject;
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
