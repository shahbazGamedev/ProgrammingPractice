using UnityEngine;

public class FogRaiser : MonoBehaviour 
{
	public int topRaiseValue;
    public int bottomRaiseValue;
    public int raiseInterval;
    public GameObject top;
    public GameObject bottom;
    
    private float nextRaise;
    private bool raised = false;
    private EllipsoidParticleEmitter topEmitter;
    private EllipsoidParticleEmitter bottomEmitter;
    
    public void Start () 
    {
        topEmitter = top.GetComponent<EllipsoidParticleEmitter>();
        bottomEmitter = bottom.GetComponent<EllipsoidParticleEmitter>();
        
	    IncrementInterval();
	}
	
	public void Update () 
    {
	   if (Time.time > nextRaise)
        {
            if (!raised)
            {
                raised = true;
                Raise();
            }
            else
            {
                raised = false;
                Lower();
            }
            
            IncrementInterval();
        }
	}
    
    private void Lower()
    {
        topEmitter.minSize = 1;
        topEmitter.maxSize = 2;
        
        bottomEmitter.minSize = 1;
        bottomEmitter.maxSize = 2;
    }
    
    private void Raise()
    {
        topEmitter.minSize = topRaiseValue;
        topEmitter.maxSize = topRaiseValue;
        
        bottomEmitter.minSize = bottomRaiseValue;
        bottomEmitter.maxSize = bottomRaiseValue;
    }
    
    private void IncrementInterval()
    {
        nextRaise = Time.time + raiseInterval;
    }
}
