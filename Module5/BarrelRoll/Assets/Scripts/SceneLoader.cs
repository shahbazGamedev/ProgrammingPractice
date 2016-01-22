using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static int sceneToLoad;

    public void LoadScene(int sceneId)
    {
        Application.LoadLevel(sceneId);
    }

    public void LoadScene()
    {
        Application.LoadLevel(sceneToLoad);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
                 Application.OpenURL(webplayerQuitURL);
        #else
                 Application.Quit();
        #endif
    }
}
