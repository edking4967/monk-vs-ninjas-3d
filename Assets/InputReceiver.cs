using UnityEngine;
using System.Collections;
using GameEvents;

public class InputReceiver : MonoBehaviour, GameEventListener
{

	// Use this for initialization
	void Start ()
	{
		GameEventManager.registerListener(this);	

	}

	public void eventReceived(GameEvent e)
	{
		if (e is PlayerMoveEvent)
			//animator.Play ("running");
		
		if (e is PlayerJumpEvent)
			GetComponent<PlayerState> ().doJump ();
		
		if (e is PlayerStopEvent) {
		}
	}

}

