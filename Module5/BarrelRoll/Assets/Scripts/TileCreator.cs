using UnityEngine;

public class TileCreator : MonoBehaviour
{
    public float heightOfGrid = 0.71f;
    public GameObject gridModel;
    public GameObject edgeModel;

    private Transform newObject;
    private GameObject edges;
    private Vector3 halfExtents;
    
    public void Start()
    {
        edges = new GameObject("Edges");
        edges.transform.position = new Vector3(0, 2.72f, 0);
        halfExtents = new Vector3(0.2f, 0.5f, 0.2f);
        
        Generate();
    }

    private void Generate()
    {
        foreach (Transform child in transform)
        {
            GenerateGrid(child);
        }
        foreach (Transform child in transform)
        {
            GenerateEdge(new Vector3(0.5f, 0.72f, 0), child);
            GenerateEdge(new Vector3(0, 0.72f, 0.5f), child);
            GenerateEdge(new Vector3(0, 0.72f, -0.5f), child);
            GenerateEdge(new Vector3(-0.5f, 0.72f, 0), child);
        }
    }
    
    private void GenerateGrid(Transform child)
    {
        Vector3 newPosition = child.gameObject.transform.position + new Vector3(0, heightOfGrid, 0);
        GameObject grid = Instantiate(gridModel, newPosition, child.gameObject.transform.rotation) as GameObject;
        grid.transform.parent = child;
    }
    
    private void GenerateEdge(Vector3 position, Transform child)
    {
        position += child.gameObject.transform.position;

        if (!Physics.CheckBox(position, halfExtents))
        {
            GameObject edge = Instantiate(edgeModel, position, child.gameObject.transform.rotation) as GameObject;
            edge.transform.parent = edges.transform;
        }
    }
}
