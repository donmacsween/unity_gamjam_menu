using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private Slider     progressBar;
    [SerializeField] private string[]   tips;
    [SerializeField] private TMP_Text   tipText;
    [SerializeField] private Sprite[]   backgrounds;
    [SerializeField] private Image      backgroundImage;

    void OnEnable()
    {
        // if we have any backgrounds to show
        if (backgrounds.Length > 0)
        {
            // Change the background image to a random one from the array
            backgroundImage.sprite = backgrounds[Random.Range(0, backgrounds.Length)];
        }
    }

    public void Load (int sceneIndex)
    {
        // start loading the scene
        StartCoroutine(LoadAsyncByIndex(sceneIndex));
        // Show tips
        if (tips.Length > 0) 
        {
            // call the Show tips method immediatly and every 3 second thereafter
            InvokeRepeating("ShowTips", 0, 3); 
        }
    }
   
    IEnumerator LoadAsyncByIndex (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            progressBar.value = (operation.progress / .9f) * 100;
            yield return null;
        }
    }

    private void ShowTips()
    {
        // Change the tip text for a random tip from the array
        tipText.text = tips[Random.Range(0, tips.Length)];
    }
}
