using UnityEngine;
using System.Collections;

public class WaterCollision : MonoBehaviour {

    public GameObject splash;

    private bool hasSplashed;
    private LevelEndManager levelManager;

    void Start()
    {
        hasSplashed = false;
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelEndManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block" && !hasSplashed && levelManager.died)
        {
            splash.transform.position = other.transform.position;
            Instantiate(splash);
            hasSplashed = true;
        }
    }
}
