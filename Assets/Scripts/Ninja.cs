using UnityEngine;
using System.Collections;

public class AIBrain{ 
   private AIState state;
   private Component c;

   public AIBrain(Component c)
   {
         this.c = c; 
   } 

   public Component getComponent() { return this.c; }

   public void transitionToState(AIState s)
   {
        this.state=s;
        s.start();
   } 

   public void setAIState(AIState state)
   {
       this.state = state;
       state.start();
   }
   public void update()
   {
        state.checkTransition();
        state.update();
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
		return c.gameObject.transform.position - getPlayer ().transform.position;
	}

    public void turnToPlayer()
    {
        Vector3 v = vectorToPlayer ();
		c.gameObject.transform.forward = v.normalized;
		c.gameObject.transform.Rotate (new Vector3 (0, 180));
    }
	
}

public abstract class AIState{

    // State machine type thing for AI
    // design questions: does checkTransition return a bool and you check each? 
    // Or one central one

    protected AIBrain b;
    protected Animator animator;
    protected Component c;
    protected GameObject n;

    public abstract void checkTransition();
    public AIState(AIBrain b)
    {
        this.b = b;
        this.c = b.getComponent() ;
        n = c.gameObject;
    }
    public abstract void start();
    public abstract void update();
    public abstract void end();

}

public class RestingState: AIState{

    public RestingState(AIBrain b) : base(b){}
    public override void checkTransition()
    {
        if(b.distanceFromPlayer() < 15)
            b.transitionToState(new RunningState(b));
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
    public RunningState(AIBrain b) : base(b){}
    public override void start()
    {
        c.GetComponent<Animator>().Play("running");
    }
    public override void checkTransition()
    {
        if(b.distanceFromPlayer() >= 15)
            b.transitionToState(new RestingState(b));

    }
    public override void update()
    {
        // Get monk position, run towards until close. Then attack
        
        b.turnToPlayer();
	
    }
    public override void end()
    {
    }
}

// just need to play once at state transition, not at update  ~ !
//  Can just 

public class Damaged : AIState{
    public Damaged(AIBrain b) : base(b){}
    
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

	// Use this for initialization
    private AIBrain b;

	void Start () {
        b = new AIBrain(this);
        b.setAIState(new RestingState(b));
	}

    public void run(Vector3 direction)
    {
    }

    public void turn(Quaternion q)
    {
        transform.rotation = q;

    }
    

	// Update is called once per frame
	void Update () {
        b.update();	
	}
}
