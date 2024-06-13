using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModuleContentController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private ModuleImageController imageController;
    [SerializeField] private GameObject imagesContainer;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private RectTransform rectTransform;

    private static ModuleContentController instance;


    void Awake()
    {
        instance = this;
    }

    public static void SetContent(string title, ModuleItem moduleItem)
    {
        instance.titleText.text = title;
        instance.imageController.SetSprites(moduleItem.sprites);
        instance.descriptionText.text = moduleItem.description;
        instance.imagesContainer.SetActive(moduleItem.sprites.Length != 0);

        instance.scrollRect.verticalNormalizedPosition = 1f;

        LayoutRebuilder.ForceRebuildLayoutImmediate(instance.rectTransform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(instance.rectTransform);
    }
}
