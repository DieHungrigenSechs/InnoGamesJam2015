using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerHud : BasicHud
{
	[SerializeField] Slider slider;
	PlayerHealth health;

	protected override void Awake ()
	{
		base.Awake ();
		health = GameObject.FindObjectOfType<PlayerHealth>();
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
