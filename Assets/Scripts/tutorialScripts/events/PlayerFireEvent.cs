﻿//////////////////////////////////////////////////////////////////////////////
// PlayerMoveEvent
//////////////////////////////////////////////////////////////////////////////
// This event is dispatched when a movement key is pressed.
//////////////////////////////////////////////////////////////////////////////

//default namespaces
using UnityEngine;
using System.Collections;

//Add access to game events classes
using GameEvents;

//PlayerMoveEvent is a GameEvent
public class PlayerFireEvent : GameEvent
{

   ///////////////////////////////////////////////////////////////////////////
   // EVENT DATA
   ///////////////////////////////////////////////////////////////////////////
   
   
   ///////////////////////////////////////////////////////////////////////////
   // CONSTRUCTOR
   ///////////////////////////////////////////////////////////////////////////
   
	public PlayerFireEvent()
   {
       Debug.Log("PlayerFireEvent constructor");
   }

}
