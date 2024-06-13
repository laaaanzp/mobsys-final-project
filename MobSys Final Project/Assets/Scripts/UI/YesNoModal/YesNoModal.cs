using System;
using TMPro;
using UnityEngine;

public class YesNoModal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private CanvasGroup canvasGroup;

    private Action yesAction;
    private Action noAction;



    public void Open(string title, Action yesAction, Action noAction)
    {
        titleText.text = title;
        canvasGroup.alpha = 1f;
        this.yesAction = yesAction;
        this.noAction = noAction;
    }

    public void YesCallback()
    {
        yesAction?.Invoke();
        Destroy(gameObject);
    }

    public void NoCallback()
    {
        noAction?.Invoke();
        Destroy(gameObject);
    }
}
