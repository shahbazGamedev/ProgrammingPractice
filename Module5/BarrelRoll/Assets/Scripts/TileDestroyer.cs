using System.Collections.Generic;
using UnityEngine;

public class TileDestroyer : MonoBehaviour
{
	public Material destroyedMaterial;
    public Material notDestroyedMaterial;
	public int tilesToDestroy;
    public GameObject barrel;
    public float interval;
    public bool randomGeneration;
    
    private float switchPeriod;   
    private List<int> tilesIndeces;

	public void Start ()
	{
        this.switchPeriod = Time.time + this.interval;
        this.tilesIndeces = new List<int>(tilesToDestroy);

        GenerateRandomTiles();

		ConfigureDestroyableTiles (tilesIndeces);
	}

    void Update()
    {
        if (randomGeneration)
        {
            if (Time.time > this.switchPeriod)
            {
                this.switchPeriod = Time.time + this.interval;
                ClearTiles();

                GenerateRandomTiles();
            }
        }
    }

    public void ClearTiles()
    {
        for (int i = 0; i < tilesToDestroy; i++)
        {
            Transform child = transform.GetChild(tilesIndeces[i]);
            child.GetChild(0).tag = "Untagged";
            child.GetComponent<Renderer>().material = notDestroyedMaterial;
        }
        this.tilesIndeces = new List<int>(tilesToDestroy);
    }

    public void GenerateRandomTiles()
    {
        System.Random rng = new System.Random();
        for (int i = 0; i < tilesToDestroy; i++)
        {
            int index;

            do
            {
                index = rng.Next(0, transform.childCount);
            }
            while (IsBarrelOverTile(index) || tilesIndeces.Contains(index));

            tilesIndeces.Add(index);
        }
        ConfigureDestroyableTiles(tilesIndeces);
    }
    
    private bool IsBarrelOverTile(int tileIndex)
    {
        Transform tile = transform.GetChild(tileIndex);
        Vector3 halfExtents = new Vector3(0.2f, 0.2f, 0.2f);
        Vector3 center = tile.gameObject.transform.position + new Vector3(0, 1.2f, 0);
        if (Physics.CheckBox(center, halfExtents))
        {
            return true;
        }
          
        return false;
    }

	private void ConfigureDestroyableTiles (List<int> tilesIndeces)
	{
		for (int i = 0; i < tilesToDestroy; i++) 
        {
			Transform child = transform.GetChild (tilesIndeces [i]);

            child.GetChild(0).tag = "DestroyedTile";

            //child.tag = "DestroyedTile";
			
            //child.gameObject.AddComponent<BoxCollider> ();			
            //BoxCollider collider = child.GetComponent<BoxCollider> () as BoxCollider;
            //collider.size = new Vector3 (8.5f, collider.size.y, 8.5f); 
            //collider.center = new Vector3 (0f, 8.5f, 0f);
            
            child.GetComponent<Renderer> ().material = destroyedMaterial;  
		}
	}

}
