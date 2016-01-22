using UnityEngine;

public class Edge : MonoBehaviour
{
    private GameObject levelManager;

    void Start()
    {
        levelManager = GameObject.Find("LevelManager");
    }

    public void OnTriggerEnter(Collider other)
    {
        var movement = other.GetComponent<Movement>();
        var levelEndManager = other.GetComponent<LevelEndManager>();
        if (other.tag == "Block" && !movement.stopMovement)
        {
            movement.GetComponent<Rigidbody>().useGravity = true;
            movement.GetComponent<Rigidbody>().isKinematic = false;
            movement.stopMovement = true;

            levelManager.GetComponent<LevelEndManager>().nextActionTime = Time.time + 2;
            levelManager.GetComponent<LevelEndManager>().died = true;
        }
    }
}
