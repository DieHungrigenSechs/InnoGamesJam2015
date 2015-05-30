using UnityEngine;
using System.Collections;

public class SplashScreen : BasicMenu
{
	protected override void Start ()
	{
		base.Start ();
		LoadLevel(LevelEnum.MainMenu);
	}
}
