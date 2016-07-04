//////////////////////////////////////////////////////////////////////////////
// InputManager.cs
//////////////////////////////////////////////////////////////////////////////
// This object polls Unity for input and posts relevant GameEvents.
//////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using GameEvents;

public class InputManager : MonoBehaviour
{
   ///////////////////////////////////////////////////////////////////////////
   // CLASS DATA
   ///////////////////////////////////////////////////////////////////////////
   
   //Keycodes for controls
   private KeyCode left = KeyCode.LeftArrow;
   private KeyCode right = KeyCode.RightArrow;
	private KeyCode up = KeyCode.UpArrow;
	private KeyCode down = KeyCode.DownArrow;

	private KeyCode w = KeyCode.W;
	private KeyCode s = KeyCode.S;
	private KeyCode a = KeyCode.A;
	private KeyCode d = KeyCode.D;
	private KeyCode f = KeyCode.F;


	private KeyCode space = KeyCode.Space;
   
   ///////////////////////////////////////////////////////////////////////////
   // FIXED UPDATE
   ///////////////////////////////////////////////////////////////////////////
	
	// Update is called once per frame
	void FixedUpdate () 
   {
        
      if(Input.GetKey(left))
         GameEventManager.post(new PlayerTurnEvent(new Vector3(0,-1,0)));

         
      if(Input.GetKey(right))
			GameEventManager.post(new PlayerTurnEvent(new Vector3(0,1,0)));
	
		if(Input.GetKey(up))
			GameEventManager.post(new PlayerMoveEvent(Vector3.forward));

		if(Input.GetKey(down))
			GameEventManager.post(new PlayerMoveEvent(Vector3.back));

		if(Input.GetKeyUp(up))
			GameEventManager.post(new PlayerStopEvent(Vector3.forward));
		
		if(Input.GetKeyUp(down))
			GameEventManager.post(new PlayerStopEvent(Vector3.back));

		
		if(Input.GetKey(w))
			GameEventManager.post(new CameraPivotEvent(new Vector3(1,0,0)));

		if(Input.GetKey(s))
			GameEventManager.post(new CameraPivotEvent(new Vector3(-1,0,0)));

		if(Input.GetKey(a))
			GameEventManager.post(new CameraPivotEvent(new Vector3(0,1,0)));
		
		if(Input.GetKey(d))
			GameEventManager.post(new CameraPivotEvent(new Vector3(0,-1,0)));

		if(Input.GetKey(f))
			GameEventManager.post(new PlayerFireEvent());

		         
		if (Input.GetKeyDown (space))
			GameEventManager.post (new PlayerJumpEvent ());
	}
}
