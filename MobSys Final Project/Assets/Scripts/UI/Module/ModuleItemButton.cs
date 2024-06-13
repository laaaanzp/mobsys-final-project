using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ModuleItemButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image borderImage;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private ModuleItem moduleItem;

    // Active Colors
    private Color borderImageActiveColor = new Color(0.65f, 0.64f, 0.64f, 1f);
    private Color backgroundImageActiveColor = new Color(1f, 0.9f, 0.68f, 1f);
    private Color textActiveColor = new Color(0.23f, 0.18f, 0.16f, 1f);

    // Inactive Colors
    private Color borderImageInactiveColor = new Color(1f, 1f, 1f, 0.67f);
    private Color backgroundImageInactiveColor = new Color(1f, 1f, 1f, 1f);
    private Color textInactiveColor = new Color(0.34f, 0.27f, 0.25f, 1f);


    private bool isLocked;
    private bool isSelected;
    private static List<ModuleItemButton> instances;


    void Awake()
    {
        instances = new List<ModuleItemButton>();
    }

    void Start()
    {
        instances.Add(this);
    }

    void OnEnable()
    {
        isLocked = PlayerPrefs.GetInt($"Module-{text.text}", 0) == 0;

        if (isLocked)
            SetLocked();

        else if (!isSelected)
            SetInactive();
    }

    public void OnPointerDown(PointerEventData eventData) { }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isLocked || isSelected) return;

        instances.ForEach(instance => {
            if (instance.isLocked) 
                instance.SetLocked();
            else
                instance.SetInactive();
        });
        ModuleContentController.SetContent(text.text, moduleItem); 

        SetActive();
    }

    public void SetActive()
    {
        gameObject.SetActive(true);
        isSelected = true;

        // Style
        canvasGroup.alpha = 1f;
        borderImage.color = borderImageActiveColor;
        backgroundImage.color = backgroundImageActiveColor;
        text.color = textActiveColor;
    }

    public void SetInactive()
    {
        gameObject.SetActive(true);
        isSelected = false;

        // Style
        canvasGroup.alpha = 1f;
        borderImage.color = borderImageInactiveColor;
        backgroundImage.color = backgroundImageInactiveColor;
        text.color = textInactiveColor;
    }

    public void SetLocked()
    {
        SetInactive();
        canvasGroup.alpha = 0.5f;
    }
}
