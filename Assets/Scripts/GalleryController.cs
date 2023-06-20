using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalleryController : MonoBehaviour
{
    [SerializeField] private List<string> imageUrls;
    [SerializeField] private Image imagePrefab;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;

    private void Start()
    {
        StartCoroutine(LoadImages());
    }

    IEnumerator LoadImages()
    {
        foreach (string url in imageUrls)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Texture2D img = ((DownloadHandlerTexture)request.downloadHandler).texture;
                Image newImage = Instantiate(imagePrefab, gridLayoutGroup.transform);
                newImage.sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), Vector2.zero);

                 //Добавляем функцию перехода на сцену Просмотр при нажатии на изображение
                newImage.GetComponent<Button>().onClick.AddListener(delegate { LoadViewScene(img); });
            }
        }
    }

    private void LoadViewScene(Texture2D img)
    {
        // Загружаем сцену Просмотр и передаем выбранное изображение
        SelectedImage.image = img;
        SceneManager.LoadScene(2);
    }
}