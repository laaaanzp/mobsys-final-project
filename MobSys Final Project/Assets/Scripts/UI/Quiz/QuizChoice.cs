using System;
using TMPro;
using UnityEngine;

public class QuizChoice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private Action onPress;

    public void Initialize(QuizChoiceData data)
    {
        text.text = data.text;
        onPress = data.onPress;
    }

    public void OnPress()
    {
        onPress?.Invoke();
    }
}
