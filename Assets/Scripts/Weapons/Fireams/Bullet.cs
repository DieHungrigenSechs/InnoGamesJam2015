using UnityEngine;

public class Bullet:Projectiles 
{
	protected override void Awake ()
	{
		base.Awake ();
		damage = 8;
	}

}

