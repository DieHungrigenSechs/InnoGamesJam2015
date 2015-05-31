using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerHud : BasicHud
{
	[SerializeField] Slider slider;
	[SerializeField] PlayerHealth health;
	[SerializeField] Image[] images;
	CharacterInput input;
	int action = -1;
	protected override void Awake ()
	{
		base.Awake ();

		if(!health)
		{
			health = GameObject.FindObjectOfType<PlayerHealth>();
		}

		input = health.GetComponent<CharacterInput>();

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
		if(input)
		{
			int current = input.GetAction();
			if(current != action)
			{
				for(int i = 0; i < images.Length;i++)
				{
					if(i == current)
					{
						images[i].enabled = false;
					}
					else
					{
						images[i].enabled = true;
					}
				}

				action = current;
			}
		}
	}


}
