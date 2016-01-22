using System.Collections;
using UnityEngine;

public class FallingBall : MonoBehaviour
{
    public int damage = 5;
    public float fallTime = 0;
    public Vector3 endPosition;
    public GameObject explosion;
    public AudioSource fallenBallSound;

    private Vector3 startPosition;
    private bool moving;

    public void Start()
    {
        startPosition = transform.position;
    }

    public void Update()
    {
        StartCoroutine(MoveFromTo(startPosition, endPosition, fallTime));
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Grid")
        {
            this.fallenBallSound.Play();
            Destroy(GameObject.Find(transform.parent.name));
        }

        if (col.gameObject.tag == "Block")
        {
            Destroy(GameObject.Find(transform.parent.name));
            col.gameObject.GetComponent<DurabilityManager>().Take(damage);
            explosion.transform.position = col.gameObject.transform.position;
            Instantiate(explosion);
        }
    }

    IEnumerator MoveFromTo(Vector3 pointA, Vector3 pointB, float time)
    {
        if (!moving)
        { 
            // do nothing if already moving
            moving = true; // signals "I'm moving, don't bother me!"
            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime / time; // sweeps from 0 to 1 in time seconds
                transform.position = Vector3.Lerp(pointA, pointB, t); // set position proportional to t
                yield return 0; // leave the routine and return here in the next frame
            }
            
            moving = false; // finished moving
        }
    }
}
