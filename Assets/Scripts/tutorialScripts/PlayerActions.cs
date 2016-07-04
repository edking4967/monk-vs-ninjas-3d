using UnityEngine;
using System.Collections;
using GameEvents;


public class PlayerActions : MonoBehaviour, GameEventListener {
	
	// Use this for initialization
	void Start () {
		GameEventManager.registerListener(this);	
	}
	
	///////////////////////////////////////////////////////////////////////////
	// EVENT LISTENING
	///////////////////////////////////////////////////////////////////////////
	
	public void eventReceived(GameEvent e)
	{
		if (e is PlayerFireEvent) {
			Debug.Log ("send fireProjectile");
			fireProjectile();
		}
	}

    public void fireProjectile()
    {
		GameObject proj = (GameObject)Instantiate(Resources.Load("Prefabs/3dproj")); 
        Vector3 fwd = GetComponent<Rigidbody>().transform.forward;
		proj.transform.position = GetComponent<Rigidbody>().transform.position;
        proj.GetComponentInChildren<Rigidbody>().AddForce(1000 * fwd);
    }
}
