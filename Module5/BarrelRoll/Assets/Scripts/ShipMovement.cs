using UnityEngine;

public class ShipMovement : MonoBehaviour 
{
	public float speed;
    
    private Vector3 startPosition;
    
    public void Start () 
    {
	   startPosition = gameObject.transform.position;
	}
	
	public void Update () 
    {
	   gameObject.transform.position += Vector3.forward * speed;
	}
    
    public void OnBecameInvisible()
    {
        Invoke("ResetPosition", 10);
    }
    
    private void ResetPosition()
    {
        gameObject.transform.position = startPosition;
    }
}
