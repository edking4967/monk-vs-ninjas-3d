using UnityEngine;
using System.Collections;

public class MonkController : MonoBehaviour {
	public bool isJumping = false;	
	public bool isFacingRight = true;
	public GameObject monk;

	public void Start()
	{
		monk = GameObject.Find ("Monk");
	}

	public void Update()
	{
		checkOffscreen ();
	}
	
	public void jump()
	{
		monk.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,200));
		isJumping = true;
		Animator anim = monk.GetComponent<Animator> ();
		anim.SetTrigger("restToJump");
		anim.StartPlayback ();
	}

	public void fireProjectile()
	{
		Debug.Log ("fireProjectile");	
		GameObject proj = (GameObject)Instantiate(Resources.Load("projectile")); 
		proj.transform.position = monk.transform.position;
		Vector2 vel = new Vector2 (.1f,0);
		if (!isFacingRight)
			vel = -vel;
		proj.GetComponent<Rigidbody2D> ().AddForce (vel);
	}

	public void checkOffscreen()
	{
		if (!monk.GetComponent<Renderer> ().isVisible ) {
			Debug.Log ("monk offcreen");
		}
	}
}
