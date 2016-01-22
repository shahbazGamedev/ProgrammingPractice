using UnityEngine;
using System.Collections;

public class UnlockLevels : MonoBehaviour {

    private int indexOfLevels;

    void Awake()
    {
        //PlayerPrefs.DeleteAll();
    }

    void Update()
    {
    }

	void Start () {

        int unlockAnimation = PlayerPrefs.GetInt("UnlockAnimation",0);
        this.indexOfLevels = PlayerPrefs.GetInt("UnlockedLevels", 0);
        if(indexOfLevels == 0)
        {
            indexOfLevels = 1;
            PlayerPrefs.SetInt("UnlockedLevels", indexOfLevels);
        }

        for (int i = 2; i <= indexOfLevels ; i++)
        {
            if (unlockAnimation == 1 && i == indexOfLevels)
            {
                PlayerPrefs.SetInt("UnlockAnimation", 0);
                Fade(GameObject.Find("Level_" + i.ToString()).transform.GetChild(1).gameObject);
                //GameObject.Find("Level_" + i.ToString()).transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                GameObject.Find("Level_" + i.ToString()).transform.GetChild(1).gameObject.SetActive(false);
            }

        }
	}

    public void Fade(GameObject objectToFade)
    {
        StartCoroutine(DoFade(objectToFade));
    }

    IEnumerator DoFade(GameObject objectToFade)
    {
        CanvasGroup canvasGroup = objectToFade.GetComponent<CanvasGroup>();

        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        objectToFade.SetActive(false);
        yield return null;
    }

}
