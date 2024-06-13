using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TextButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    [SerializeField] private Color hoveredColor = new Color(1f, 0.85f, 0f, 1f); // Gold
    [SerializeField] private UnityEvent onPress;
    [SerializeField] private float duration = 0.5f;

    private TextMeshProUGUI text;
    private bool isPressed;
    private bool isHovered;
    private Color neutralColor;


    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        neutralColor = text.color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        SetPressed();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;

        if (isPressed)
        {
            SetPressed();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        SetNeutral();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        SetNeutral();

        if (isHovered)
        {
            onPress?.Invoke();
        }
    }

    private void SetPressed()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, UpdateColorCallback, text.color, hoveredColor, duration);
    }

    private void SetNeutral()
    {
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, UpdateColorCallback, text.color, neutralColor, duration);
    }

    private void UpdateColorCallback(Color value)
    {
        text.color = value;
    }
}