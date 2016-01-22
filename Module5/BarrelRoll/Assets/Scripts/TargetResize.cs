using UnityEngine;
using System.Collections;

public class TargetResize : MonoBehaviour 
{
    public float resizeTo;
    public float overDuration;
	
	public void Update ()
    {
        StartCoroutine(this.ScaleOverTime(this.overDuration));
    }

    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = this.transform.localScale;
        Vector3 destinationScale = new Vector3(this.resizeTo, 0f, this.resizeTo);

        float currentTime = 0.0f;

        do
        {
            this.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            
            yield return null;
        }
        while (currentTime <= time);
    }
}
