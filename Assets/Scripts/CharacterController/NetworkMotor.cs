using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class NetworkMotor  : CharacterMotor
{
	Vector3 position;
	protected override void Awake ()
	{
		base.Awake ();
		position = transform.position;
	}

	protected override void FixedUpdate ()
	{
		if(!photonView.isMine)
		{
			float distance = Vector3.Distance(transform.position,position);
			if(distance >= 1f)
			{
				transform.position = position;
			}
			else
			{
				transform.position = Vector3.Lerp(transform.position,position,Mathf.Max(Time.deltaTime,distance));
			}
		}
		else
		{
			base.FixedUpdate();
		}
	}

	private void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{        
			stream.SendNext(Velocity);
			stream.SendNext(transform.position);
            stream.SendNext(IsTurnedToRight);
		}
		else
		{    
			Velocity = (Vector2)stream.ReceiveNext();
			position = (Vector3)stream.ReceiveNext();
		    IsTurnedToRight = (bool)stream.ReceiveNext();
		}
	}
}
