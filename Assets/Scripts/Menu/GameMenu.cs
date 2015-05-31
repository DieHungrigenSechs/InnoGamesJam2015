using UnityEngine;
using System.Collections;

public class GameMenu : BasicMenu 
{

	protected override void Start ()
	{
		base.Start ();
	}

	public override void LoadLevel (LevelEnum level)
	{
		base.LoadLevel (level);
		Cursor.visible = true;
	}
}
