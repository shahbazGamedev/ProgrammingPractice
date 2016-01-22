using UnityEngine;

public class DurabilityManager : MonoBehaviour
{
    public int durability = 100;
    public bool destroyed = false;
    
    private GameObject levelManager;

    void Start()
    {
        this.levelManager = GameObject.Find("LevelManager");
    }
    public void Update()
    {
        if (durability <= 0 && !destroyed)
        {
            destroyed = true;

            // destroy these because they access Rigidbody which is destroyed by triggerBreak()
            Destroy(GetComponent<GravityEnabler>());
            Destroy(GetComponent<Movement>());

            GetComponent<BreakableObject>().triggerBreak();
            levelManager.GetComponent<LevelEndManager>().nextActionTime = Time.time + 1;
            levelManager.GetComponent<LevelEndManager>().died = true;
        }
    }

    public void Take(int value)
    {
        durability -= value;
    }
}
