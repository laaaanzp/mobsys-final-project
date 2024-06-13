using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    [Header("Components and Duration")]
    [SerializeField] private Image borderImage;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private float duration = 0.5f;

    [Header("Colors (Hovered)")]
    [SerializeField] private Color borderColorHovered;
    [SerializeField] private Color backgroundColorHovered;
    [SerializeField] private Color buttonTextColorHovered;

    [Header("Events")]
    [SerializeField] private UnityEvent onPress;

    private Color borderColor;
    private Color backgroundColor;
    private Color buttonTextColor;

    private bool isPressed;
    private bool isHovered;


    void Awake()
    {
        borderColor = borderImage.color;
        backgroundColor = backgroundImage.color;
        buttonTextColor = buttonText.color;
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
            AudioPlayer.PlayButtonClick();
        }
    }

    private void SetPressed()
    {
        LeanTween.cancel(gameObject);

        // Border
        LeanTween.value(gameObject, (Color c) => {
            borderImage.color = c;
        }, borderImage.color, borderColorHovered, duration)
        .setIgnoreTimeScale(true);

        // Background
        LeanTween.value(gameObject, (Color c) => {
            backgroundImage.color = c;
        }, backgroundImage.color, backgroundColorHovered, duration)
        .setIgnoreTimeScale(true);

        // Text
        LeanTween.value(gameObject, (Color c) => {
            buttonText.color = c;
        }, buttonText.color, buttonTextColorHovered, duration)
        .setIgnoreTimeScale(true);
    }

    private void SetNeutral()
    {
        LeanTween.cancel(gameObject);

        // Border
        LeanTween.value(gameObject, (Color c) => {
            borderImage.color = c;
        }, borderImage.color, borderColor, duration)
        .setIgnoreTimeScale(true);

        // Background
        LeanTween.value(gameObject, (Color c) => {
            backgroundImage.color = c;
        }, backgroundImage.color, backgroundColor, duration)
        .setIgnoreTimeScale(true);

        // Text
        LeanTween.value(gameObject, (Color c) => {
            buttonText.color = c;
        }, buttonText.color, buttonTextColor, duration)
        .setIgnoreTimeScale(true);
    }
}
