using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void doJump()
	{
		GetComponent<PlayerAnimation> ().doJump ();
		GetComponent<PlayerMovement> ().doJump ();
	}
}

