using UnityEngine;
using System.Collections;
using GameEvents;


public class PlayerAnimation : MonoBehaviour, GameEventListener {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.Play("idle");
		GameEventManager.registerListener(this);	

	}
	
	///////////////////////////////////////////////////////////////////////////
	// EVENT LISTENING
	///////////////////////////////////////////////////////////////////////////
	
	public void eventReceived(GameEvent e)
	{
		if(e is PlayerMoveEvent)
			animator.Play ("running");

		if (e is PlayerJumpEvent)
			doJump ();

		if(e is PlayerStopEvent)
			animator.Play ("idle");
	}

	public void doJump()
	{
		animator.Play ("jumping");

	}
}
