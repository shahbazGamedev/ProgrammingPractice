using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    public GameObject target;
    public GameObject smoke;
    public float period = 5f;
    public float firstSpawnAt = 3f;
    public float targetHeight = 0f;
    public float fallTime = 3f;

    private float nextActionTime = 0f;
    private List<Transform> availablePositions;
    private List<Transform> availableCannons;

    public void Start()
    {
        nextActionTime = Time.time + firstSpawnAt;
        availablePositions = new List<Transform>();
        foreach (Transform child in GameObject.Find("Bridges").transform)
        {
            availablePositions.Add(child);
        }
        
        availableCannons = new List<Transform>();
        foreach (Transform child in GameObject.Find("Cannons").transform)
        {
            availableCannons.Add(child);
        }
    }

    public void Update()
    {
        if (Time.time > nextActionTime)
        {
            CreateObjects();
        }
    }
    
    private void CreateObjects()
    {
        nextActionTime += period;

        int randomCannonIndex = Random.Range(0, availableCannons.Count);
        smoke.transform.position = availableCannons[randomCannonIndex].transform.position;
        Instantiate(smoke);

        int randomIndex = Random.Range(0, availablePositions.Count);
        float randomX = availablePositions[randomIndex].transform.position.x;
        float randomZ = availablePositions[randomIndex].transform.position.z;

        target.transform.GetChild(1).transform.position = new Vector3(randomX, targetHeight, randomZ);

        target.transform.GetChild(2).transform.position = availableCannons[randomCannonIndex].transform.position;
        target.transform.GetChild(2).GetComponent<CannonBall>().endPosition = new Vector3(randomX, targetHeight, randomZ);
        target.transform.GetChild(2).GetComponent<CannonBall>().fallTime = fallTime;

        target.transform.GetChild(0).transform.position = new Vector3(randomX, 100f, randomZ);
        target.transform.GetChild(0).GetComponent<FallingBall>().endPosition = new Vector3(randomX, targetHeight, randomZ);
        target.transform.GetChild(0).GetComponent<FallingBall>().fallTime = fallTime;

        Instantiate(target);
    }
}