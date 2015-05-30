using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Credits : BasicMenu 
{
	[SerializeField] string[] names;
	[SerializeField] Text textField;
	[SerializeField] float speed;
	protected override void Start ()
	{
		base.Start ();
		StartCoroutine(ShowNextUser(speed,0));
	}

	private IEnumerator ShowNextUser(float time,int id)
	{
		yield return new WaitForSeconds(time);
		if(id < names.Length)
		{
			textField.text = names[id];
			id++;
			StartCoroutine(ShowNextUser(time,id));
		}
		else
		{
			GameObject.FindObjectOfType<BasicMenu>().LoadLevel(LevelEnum.MainMenu);
		}
	}
}
