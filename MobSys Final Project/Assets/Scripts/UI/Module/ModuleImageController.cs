using UnityEngine;
using UnityEngine.UI;

public class ModuleImageController : MonoBehaviour
{
    [SerializeField] private Image image;

    private Sprite[] sprites;
    private int currentIndex;


    public void SetSprites(Sprite[] sprites)
    {
        this.sprites = sprites;
        currentIndex = 0;
        SetCurrentImage();
    }

    public void Next()
    {
        if (sprites.Length == 0) return;
        currentIndex = currentIndex == sprites.Length - 1 ? 0 : currentIndex + 1;
        SetCurrentImage();
    }

    public void Previous()
    {
        if (sprites.Length == 0) return;
        currentIndex = currentIndex == 0 ? sprites.Length - 1 : currentIndex - 1;
        SetCurrentImage();
    }

    private void SetCurrentImage()
    {
        image.sprite = sprites[currentIndex];
    }
}
