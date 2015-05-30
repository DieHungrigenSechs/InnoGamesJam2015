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
		base.FixedUpdate();
		if(!photonView.isMine)
		{
			transform.position = Vector3.Lerp(transform.position,position, Time.deltaTime);
		}
	}
	
	private void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{            
			//We own this player: send the others our data
			stream.SendNext (transform.position);
		}
		else
		{    

			//Network player, receive data			
			position = (Vector3)stream.ReceiveNext();
		}
	}
}
