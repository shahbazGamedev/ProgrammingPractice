using UnityEngine;

public class GravityEnabler : MonoBehaviour
{
	private Rigidbody body;
	private Movement movement;
    private GameObject levelManager;

	public void Start ()
	{
        levelManager = GameObject.Find("LevelManager");
		movement = GetComponent<Movement> ();
		body = GetComponent<Rigidbody> ();
	}

	public void OnCollisionEnter (Collision col)
	{
		Vector3 facingSide = movement.GetDownFacingSide ();
		bool properSideFacing = (facingSide == Vector3.up || facingSide == Vector3.down);

		if (col.gameObject.tag == "FinalTile" && properSideFacing) 
        {
			Fall (col);
			levelManager.GetComponent<LevelEndManager> ().nextActionTime = Time.time + 1;
			levelManager.GetComponent<LevelEndManager> ().levelPassed = true;
		} 
        else if (col.gameObject.tag == "DestroyedTile" && properSideFacing)
        {
            levelManager.GetComponent<LevelEndManager>().nextActionTime = Time.time + 1.5f;
            levelManager.GetComponent<LevelEndManager>().died = true;
			col.gameObject.transform.parent.gameObject.AddComponent<Rigidbody> ();
			Fall (col);
		}
    }

	private void Fall (Collision col)
	{
		body.useGravity = true;
		body.isKinematic = false;
		movement.stopMovement = true;
		col.collider.enabled = false;
	}
}
