using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class TeleportGlitch : BugPhysics
{
	[SerializeField] float speed = 1f;
	[SerializeField] Vector2[] directions;
	private Color[] colors;
	SpriteRenderer[] renderers;

	protected override void Awake ()
	{
		base.Awake ();
		renderers = GetComponentsInChildren<SpriteRenderer>();
	}
	protected override void Start ()
	{
		base.Start ();

		if(directions == null)
		{
			directions = new Vector2[Random.Range(0,10)];
			for(int i = 0; i < directions.Length;i++)
			{
				directions[i] = new Vector2(Random.Range(5,200),0);
			}
		}
		colors = new Color[renderers.Length];
		for(int i = 0; i < renderers.Length;i++)
		{
			colors[i] = renderers[i].color;
		}

		if(directions.Length > 0)
		{
			StartCoroutine(GoBackToPosition(speed,directions.Length));
		}
	}
	protected override void Update ()
	{
		base.Update ();
	}

	private IEnumerator Flickered(float time,int count)
	{
		yield return new WaitForFixedUpdate();
		if(count > 0)
		{
			for(int i = 0; i < renderers.Length;i++)
			{
				Color color = renderers[i].color;
				color.a = Flash(colors[i].a,Random.Range(0.5f,1f),Random.Range(0.5f,1f));
				renderers[i].color = color;
			}
			count--;
			StartCoroutine(Flickered(time,count));
		}
		else
		{
			for(int i = 0; i < renderers.Length;i++)
			{
				renderers[i].color = this.colors[i];
			}
		}
	}

	private IEnumerator GoBackToPosition(float time,int count)
	{
		StartCoroutine(Flickered(Time.deltaTime, 100));
		yield return new WaitForSeconds(time);
		transform.position += (Vector3)directions[Mathf.Clamp(count,0,directions.Length-1)] * Time.deltaTime * transform.localScale.x;
		if(count > 1)
		{
			count--;
			StartCoroutine(GoBackToPosition(time,count));
		}
	}

	protected override void Reset ()
	{
		base.Reset ();
		for(int i = 0; i < renderers.Length;i++)
		{
			renderers[i].color = colors[i];
		}
	}

}
