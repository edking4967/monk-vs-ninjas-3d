using UnityEngine;
using System.Collections;

public abstract class Bot{

}

// Move AIState up to its own thing 
public abstract class AIState{

    // State machine type thing for AI
    // design questions: does checkTransition return a bool and you check each? 
    // Or one central one

    protected Animator animator;
    protected Component c;
    protected Bot n;

    public abstract void checkTransition();
    public AIState(Component c)
    {
        this.c = c ;
        n = (Bot) c;
    }
    public abstract void start();
    public abstract void update();
    public abstract void end();

    public void setAnimator(Animator a)
    {
        animator = a;
    }

    public static GameObject getPlayer()
    {
        return GameObject.FindGameObjectsWithTag("Player")[0]; 
    }

    public float distanceFromPlayer()
    {
        GameObject player = getPlayer(); 
        return Vector3.Distance(player.transform.position, c.gameObject.transform.position);
    }
	public Vector3 vectorToPlayer()
	{
		return n.transform.position - getPlayer ().transform.position;
	}
}

public class RestingState: AIState{

    public RestingState(Component c) : base(c){}
    public override void checkTransition()
    {
        if(distanceFromPlayer() < 15)
            ((Ninja) c).transitionToState(new RunningState(c));
    }
    public override void start()
    {
        c.GetComponent<Animator>().Play("idle");
    }
    public override void update()
    {
        
    }
    public override void end()
    {

    }
}

public class RunningState: AIState{
    public RunningState(Component c) : base(c){}
    public override void start()
    {
        c.GetComponent<Animator>().Play("running");
    }
    public override void checkTransition()
    {
        if(distanceFromPlayer() >= 15)
            n.transitionToState(new RestingState(c));

    }
    public override void update()
    {
        // Get monk position, run towards until close. Then attack
        
        n.turnToPlayer();

		Vector3 v = vectorToPlayer ();
		n.transform.forward = v.normalized;
		n.transform.Rotate (new Vector3 (0, 180));
    }
}

// just need to play once at state transition, not at update  ~ !
//  Can just 

public class Damaged : AIState{
    public Damaged(Component c) : base(c){}
    
    public override void checkTransition()
    {
        // if gets hit by something, start state
    }
    public override void start()
    {
        // flash red / effect
    }
    public override void update()
    {
        // check timer 
    }
    public override void end()
    {

    }
}

public class Ninja : MonoBehaviour {
    private AIState state;
	// Use this for initialization

	void Start () {
        state = new RestingState(this); 
        state.setAnimator(GetComponent<Animator>());
        state.start();
	}

    public void transitionToState(AIState s)
    {
        state = s;
        s.start();
    }

    public void run(Vector3 direction)
    {
    }

    public void turn(Quaternion q)
    {
        transform.rotation = q;

    }
    
    // TODO: getPlayer() goes on a global scope
    public void turnToPlayer()
    {
        GameObject player = AIState.getPlayer();  
        Quaternion playerRota = player.transform.rotation; 
        turn(playerRota);
		transform.Rotate (new Vector3 (0,180)); 

    }
	
	// Update is called once per frame
	void Update () {
        state.checkTransition();
        state.update();	
	}
}
