using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    //A variable to hold the loading screen
    public GameObject loadingScreen;

    //A variable for the loading slider
    public Slider loadingSlider;

    //A variable that holds the progress text in percentage
    public Text progressText;

    
    public void LoadLevel(int sceneIndex)
    {
        //Calls the load function
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        //This loads the next scene while keeping the behaviours in the current scene running. This operation progress is stored in the variable
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        //The loading screen is activated in the hierarchy
        loadingScreen.SetActive(true);

        //While this loading operation is not done...
        while (!operation.isDone)
        {
            //...a calculation to ensure the progress value goes up to 1 instead of 0.9
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            //updates the value of the slider and percentage text
            loadingSlider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;//This waits a frame before continuing the while loop
        }
    }
}
