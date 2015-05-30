using UnityEngine;
using UnityEngine.UI;

public class BasicMenu : MonoBehaviour 
{
	private LevelEnum level;
	private bool isLoading = false;

	// Use this for initialization
	protected virtual void Start() 
	{
	}

	// Update is called once per frame
	protected virtual void Update () 
	{

	}

	private void LoadLevel()
	{
		if(level != LevelEnum.None && !isLoading)
		{
			switch(level)
			{
			case LevelEnum.Quit:
				Application.Quit();
				break;
			default:
				Application.LoadLevel(level.ToString());
				break;
			}

			isLoading = true;
		}
	}
	
	public virtual void LoadLevel(LevelEnum level)
	{
		this.level = level;
		LoadLevel();
	}

	public void LoadLevel(string level)
	{
		LoadLevel((LevelEnum)System.Enum.Parse(typeof(LevelEnum), level));
	}
}
