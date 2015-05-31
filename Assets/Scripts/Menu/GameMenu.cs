using UnityEngine;
using System.Collections;

public class GameMenu : BasicMenu 
{
	public override void LoadLevel (LevelEnum level)
	{
		base.LoadLevel (level);
		Cursor.visible = true;
	}
}
