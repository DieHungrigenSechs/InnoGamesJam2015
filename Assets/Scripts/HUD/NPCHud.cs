using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NPCHud : BasicHud
{
	[SerializeField] Slider slider;
	NPCHealth health;
	protected override void Awake ()
	{
		base.Awake ();
		health = GameObject.FindObjectOfType<NPCHealth>();
	}
	
	protected override void Start ()
	{
		base.Start ();
		
		slider.minValue = 0f;
		slider.maxValue = 100f;
	}
	
	protected override void Update ()
	{
		base.Update ();
		slider.value = health.Energy;
	}
}
