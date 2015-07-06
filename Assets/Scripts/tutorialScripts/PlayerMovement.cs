//////////////////////////////////////////////////////////////////////////////
// PlayerMovement.cs
//////////////////////////////////////////////////////////////////////////////
// This script listens for PlayerMoveEvents and moves the attached object
// accordingly.
//////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using GameEvents;

public class PlayerMovement : MonoBehaviour, GameEventListener 
{

   ///////////////////////////////////////////////////////////////////////////
   // CONSTANTS
   ///////////////////////////////////////////////////////////////////////////
   
   	const float moveAmount = 0.16f;
	const float turnAmount = 1f;
	const float cameraPivotAmount = 1f;

	Animator animator;
   ///////////////////////////////////////////////////////////////////////////
   // START FUNCTION
   ///////////////////////////////////////////////////////////////////////////


	// Use this for initialization
	void Start () 
   {
		animator = GetComponent<Animator> ();
      	GameEventManager.registerListener(this);	
		animator.Play("idle");

	}

	
   ///////////////////////////////////////////////////////////////////////////
   // EVENT LISTENING
   ///////////////////////////////////////////////////////////////////////////
   
   public void eventReceived(GameEvent e)
   {
      if (e is PlayerMoveEvent)
      {
         Vector3 d = (e as PlayerMoveEvent).direction;
         
         transform.Translate(d*moveAmount);
      }

		if (e is PlayerTurnEvent)
		{
			Vector3 d = (e as PlayerTurnEvent).direction;

			transform.Rotate(d*turnAmount);

		}

		if (e is CameraPivotEvent)
		{
			Vector3 d = (e as CameraPivotEvent).direction;
			
			GetComponentInChildren<Camera>(). transform.Rotate(d*cameraPivotAmount);
		}

		if (e is PlayerJumpEvent) {

			doJump();

		}
   }

	public void doJump()
	{
		GetComponent<Rigidbody>().AddForce(new Vector3(0,500,0));

	}
	
}
