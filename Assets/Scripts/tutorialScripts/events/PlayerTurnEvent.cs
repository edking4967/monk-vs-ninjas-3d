﻿

//////////////////////////////////////////////////////////////////////////////
// PlayerTurnEvent
//////////////////////////////////////////////////////////////////////////////
// This event is dispatched when a left/right movement key is pressed.
//////////////////////////////////////////////////////////////////////////////

//default namespaces
using UnityEngine;
using System.Collections;

//Add access to game events classes
using GameEvents;

//PlayerMoveEvent is a GameEvent
public class PlayerTurnEvent : GameEvent
{

   ///////////////////////////////////////////////////////////////////////////
   // EVENT DATA
   ///////////////////////////////////////////////////////////////////////////
   
   public Vector3 direction;
   
   ///////////////////////////////////////////////////////////////////////////
   // CONSTRUCTOR
   ///////////////////////////////////////////////////////////////////////////
   
   public PlayerTurnEvent(Vector3 d)
   {
      direction = d;
   }

}
