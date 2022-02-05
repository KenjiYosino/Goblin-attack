using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] private Slider loadSlider;
    private int sceneID = 1;    

    private void Start()
    {
        StartCoroutine(LoaadNextScene());
    }
  
    private IEnumerator LoaadNextScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneID);
        while (!asyncOperation.isDone)
        {
            Time.timeScale = 1f;
            float progress = asyncOperation.progress / 0.9f;
            loadSlider.value = progress;
            yield return null;
        }
    }
}
