using UnityEngine;

public class LevelEndManager : MonoBehaviour
{
    public static bool isGamePaused;

    public bool levelPassed = false;
    public bool died = false;
    public float nextActionTime;

    private int gameOverScreenIndex = 1;
    private int levelSelectIndex = 2;
    private int finalLevelIndex = 14;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

        if (levelPassed)
        {
            if (Time.time > this.nextActionTime)
            {
                if (Application.loadedLevel < this.finalLevelIndex)
                {
                    int levelToUnlock = PlayerPrefs.GetInt("UnlockedLevels");

                    if (levelToUnlock == (Application.loadedLevel - 2))
                    {
                        levelToUnlock += 1;
                        PlayerPrefs.SetInt("UnlockAnimation", 1);
                        PlayerPrefs.SetInt("UnlockedLevels", levelToUnlock);
                    }
                    SceneLoader.sceneToLoad = Application.loadedLevel + 1;
                    Application.LoadLevel(this.levelSelectIndex);
                }
                else
                {
                    Application.LoadLevel(this.levelSelectIndex);
                }
            }
        }
        else if (died)
        {
            if (Time.time > this.nextActionTime)
            {
                SceneLoader.sceneToLoad = Application.loadedLevel;
                Application.LoadLevel(this.gameOverScreenIndex);
            }
        }
    }

    public static void PauseGame()
    {
        if (!isGamePaused)
        {
            Time.timeScale = 0;
            isGamePaused = true;
            GameObject.Find("UI").transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            isGamePaused = false;
            GameObject.Find("UI").transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
