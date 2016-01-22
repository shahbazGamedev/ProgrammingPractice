using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool stopMovement;
    public int durabilityCost = 5;
    public AudioSource movementSound;

    private Transform parent;
    private Vector3[] directions;
    private Rigidbody body;
    private float speed = 250f;
    private Quaternion to;
    private Vector3 axis;

    public void Start()
    {
        parent = new GameObject().transform;
        directions = new Vector3[] { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };
        to = parent.rotation;
        body = GetComponent<Rigidbody>();
        stopMovement = false;
    }

    public void Update()
    {
        if (!LevelEndManager.isGamePaused)
        {
            if (!stopMovement && !body.isKinematic)
            {
                bool moved = false;

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    FlopTheBlock(Vector3.left);
                    moved = true;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    FlopTheBlock(Vector3.right);
                    moved = true;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    FlopTheBlock(Vector3.forward);
                    moved = true;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    FlopTheBlock(Vector3.back);
                    moved = true;
                }

                if (moved)
                {
                    GetComponent<DurabilityManager>().Take(durabilityCost);
                }
            }

            if (parent.rotation != to)
            {
                parent.rotation = Quaternion.RotateTowards(parent.rotation, to, speed * Time.deltaTime);
            }
            else if (!stopMovement)
            {
                body.isKinematic = false;
            }
        }
    }

    public void FlopTheBlock(Vector3 direction)
    {
        Vector3 dir = transform.InverseTransformDirection(direction);
        Vector3 down = GetDownFacingSide();

        Vector3 position = dir * 0.5f + down * 0.5f;
        position = transform.TransformPoint(position);

        transform.parent = null;
        parent.rotation = Quaternion.identity;
        parent.position = position;
        transform.parent = parent;

        axis = Vector3.Cross(Vector3.down, direction);
        to = Quaternion.AngleAxis(-90f, axis);
        body.isKinematic = true;

        StartCoroutine(PlaySound());
    }

    public Vector3 GetDownFacingSide()
    {
        Vector3 direction = new Vector3();

        for (var i = 0; i < directions.Length; i++)
        {
            if (Vector3.Dot(transform.TransformDirection(directions[i]), Vector3.down) > 0.9)
            {
                direction = directions[i];
                break;
            }
        }

        return direction;
    }

    private IEnumerator PlaySound() 
    {
        yield return new WaitForSeconds(0.2f);
        movementSound.Play();
    }
}