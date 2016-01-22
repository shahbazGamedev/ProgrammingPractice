using System;
using UnityEngine;

public class WaterRaiser : MonoBehaviour 
{
    public float raiseInterval= 4f;
    public float lowerInterval = 3f;
    public float raiseValue = 0.78f;
    public GameObject barrel;
    public float damage = 1f;
    
    private GameObject levelManager;   
    private float nextChange;
    private bool raised = false;
    private float timeToTakeDamage;
    private float damageInterval = 1f;
    
	public void Start () 
    {
        GameObject.Find("Bridges").GetComponent<TileDestroyer>().ClearTiles();
        GameObject.Find("Bridges").GetComponent<TileDestroyer>().GenerateRandomTiles();
        this.levelManager = GameObject.Find("LevelManager");
        nextChange = Time.time + raiseInterval;
    }

    public void Update () 
    {
        Vector3 currentPostion = gameObject.transform.position;
        
	    if (Time.time > nextChange)
        {
            if (!raised)
            {
                LowerLevelCheck(currentPostion);
            }
            else
            {
               RaiseLevelCheck(currentPostion);
            }
        }

        if (raised)
        {
            if (Time.time > timeToTakeDamage)
            {
                timeToTakeDamage = Time.time + damageInterval;
                barrel.GetComponent<DurabilityManager>().Take(1);
            }
        }
	}
    
    private void LowerLevelCheck(Vector3 currentPostion)
    {
        if (currentPostion.y <= raiseValue)
        {
            RaiseLevel();
        }
        else
        {
            raised = true;
            nextChange = Time.time + lowerInterval;
        }
    }
    
    private void RaiseLevelCheck(Vector3 currentPostion)
    {
        if (currentPostion.y >= 0f)
        {
            LowerLevel();
        }
        else
        {
            raised = false;
            GameObject.Find("Bridges").GetComponent<TileDestroyer>().ClearTiles();
            GameObject.Find("Bridges").GetComponent<TileDestroyer>().GenerateRandomTiles();
            nextChange = Time.time + raiseInterval;
        }
    }
    
    private void LowerLevel()
    {
        gameObject.transform.position -= new Vector3(0f, 0.008f, 0f);
    }
    
    private void RaiseLevel()
    {
        gameObject.transform.position += new Vector3(0f, 0.005f, 0f);
    }
}
