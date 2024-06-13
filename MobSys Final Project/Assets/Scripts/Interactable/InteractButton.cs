using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI text;
    private static InteractButton instance;
    private Interactable interactable;

    void Awake()
    {
        instance = this;
        Hide();
    }

    public static void Show(Interactable interactable)
    {
        instance.interactable = interactable;
    }

    public static void Hide()
    {
        instance.interactable = null;
    }

    void Update()
    {
        if (interactable != null && interactable.isInteractable)
        {
            instance.text.text = interactable.interactionName;
            instance.canvasGroup.alpha = 1f;
            instance.canvasGroup.interactable = true;
        }
        else
        {
            instance.canvasGroup.alpha = 0f;
            instance.canvasGroup.interactable = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        interactable?.onInteract?.Invoke();
    }
}
