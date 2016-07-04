using UnityEngine;
using System.Collections;

public class FlashRed : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Color redColor = new Color(1.0f,0.0f,0.0f,1.0f);
        GetComponentsInChildren<Renderer>()[0].material.SetColor("_Color", redColor);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
