using UnityEngine;
using System.Collections;

public class FlashRed : MonoBehaviour {
    
    private int timerInterval = 0;
    private int startTime = 0;
    private Color startColor;
    private GameObject marker;

	// Use this for initialization
	void Start () {
        // Save original color
        startColor = GetComponentsInChildren<Renderer>()[0].material.GetColor("_Color");
        marker = GameObject.Find("Marker");
        marker.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if( (int) (Time.time * 1000) - startTime >= timerInterval )
        {
            clearTint();
        }
        // TODO: only set once
	}

    void setColor(Color c)
    {
        GetComponentsInChildren<Renderer>()[0].material.SetColor("_Color", c);
    }

    Color getColor()
    {
        return GetComponentsInChildren<Renderer>()[0].material.GetColor("_Color")
    }

    void clearTint()
    {
        if( getColor() == startColor)
            return;
        else
            setColor(startColor);
    }

    void setTimer(int msec, int startTime)
    {
       this.timerInterval = msec; 
       this.startTime = startTime;
    }

    public void flashForMsec(int msec)
    {
        Color redColor = new Color(1.0f,0.0f,0.0f,1.0f);
        setColor(redColor);
        setTimer(msec, (int) (Time.time * 1000) );
        setMarkerOn();
    }

    // Can only have one marker max!
    public void setMarkerOn()
    {
        marker.GetComponent<Renderer>().enabled = true;
    }

    public void setMarkerOff()
    {
        marker.GetComponent<Renderer>().enabled = false;
    }
}
