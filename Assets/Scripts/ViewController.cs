using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour
{
    [SerializeField] private Image imageView;
    
    private void Start()
    {
        imageView.sprite = Sprite.Create(
            SelectedImage.image, 
            new Rect(0, 0, SelectedImage.image.width, SelectedImage.image.height), 
            Vector2.zero);
    }

}
