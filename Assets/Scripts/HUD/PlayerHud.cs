using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerHud : BasicHud
{
	[SerializeField] Slider slider;
	[SerializeField] PlayerHealth hud;
	PlayerHealth health;

	protected override void Awake ()
	{
		base.Awake ();

		if(!health)
		{
			health = GameObject.FindObjectOfType<PlayerHealth>();
		}
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
