using UnityEngine;
using System.Collections;

public class Turtle : MonoBehaviour {

	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "Player") {
			GetComponent<Rigidbody>().AddForce(new Vector3(900f,900f,900f));
			Debug.Log ("asdasd");
		}
	}
}
