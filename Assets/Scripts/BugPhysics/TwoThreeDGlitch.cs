using UnityEngine;
using System.Collections;

public class TwoThreeDGlitch : MonoBehaviour 
{
	private enum TargetGraphics { ThreeD, TwoD}
	[SerializeField] TargetGraphics graphics;
	[SerializeField] GameObject[] models;
	[SerializeField] float randomValue;
	private Collider2D collider;

	private void Awake ()
	{

	}
	private void Start ()
	{
		StartCoroutine(AutomaticGraphicsChanger(0,graphics));
	}

	private IEnumerator AutomaticGraphicsChanger(float time,TargetGraphics graphics)
	{
		yield return new WaitForSeconds(time);
		ChangeAsset(graphics);
		if(graphics == TargetGraphics.ThreeD)
		{
			StartCoroutine(AutomaticGraphicsChanger(Random.Range(0,randomValue),TargetGraphics.TwoD));
		}
		else
		{
			StartCoroutine(AutomaticGraphicsChanger(Random.Range(0,randomValue),TargetGraphics.ThreeD));
		}

	}

	private void ChangeAsset(TargetGraphics graphics)
	{
		int layer = LayerMask.NameToLayer("Invisible");
		int defaultLayer = LayerMask.NameToLayer("Default");
		switch(graphics)
		{
		case TargetGraphics.TwoD:
			ChangeLayer(0,defaultLayer);
			ChangeLayer(1,layer);
			break;
		case TargetGraphics.ThreeD:
			ChangeLayer(0,layer);
			ChangeLayer(1,defaultLayer);
			break;
		}
	}

	private void ChangeLayer(int id,int layer)
	{
		foreach(Transform transf in models[Mathf.Clamp(id,0,models.Length-1)].GetComponentsInChildren<Transform>())
		{
			transf.gameObject.layer = layer;
		}
	}


}
