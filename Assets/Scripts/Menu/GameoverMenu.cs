using UnityEngine;
using System.Collections;

public class GameoverMenu : BasicMenu 
{
	[SerializeField] float wait = 2f;
	private IEnumerator Start()
	{
		yield return new WaitForSeconds(wait);
		LoadLevel(LevelEnum.MainMenu);
	}
}
