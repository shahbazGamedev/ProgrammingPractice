using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float distanceX = 5f;
    public float distanceY = 6f;

    private GameObject block;
    private LevelEndManager levelManager;

    public void Start()
    {
        block = GameObject.Find("Block");
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelEndManager>();
    }

    public void Update()
    {
        if (block && !levelManager.died && !levelManager.levelPassed)
        {
            Vector3 blockPosition = block.transform.position;
            gameObject.transform.position = new Vector3(blockPosition.x - distanceX, distanceY, blockPosition.z);
        }
    }
}
