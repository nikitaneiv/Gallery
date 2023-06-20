using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider bar;
    [SerializeField] private TextMeshProUGUI progressText;
    
    public void LoadScene(int _sceneNumber)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(_sceneNumber));
    }

    IEnumerator LoadAsync(int _sceneNumber)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneNumber);
        
        while (!asyncLoad.isDone)
        {
            bar.value = asyncLoad.progress;
            progressText.text = string.Format("{0}",Mathf.Round(asyncLoad.progress * 100f)); 
            yield return null;
        }
    }
    
    public void CloseGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
    }
}
