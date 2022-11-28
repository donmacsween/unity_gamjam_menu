using UnityEngine;

public class QuitGame : MonoBehaviour
{
    [SerializeField] 
    string webplayerQuitURL = "http://google.com";
    
    public void Quit(string webplayerQuitURL = "http://google.com")
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
