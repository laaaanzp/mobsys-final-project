using System;

public class QuizChoiceData
{
    public string text;
    public Action onPress;

    public QuizChoiceData(string text, Action onPress)
    {
        this.text = text;
        this.onPress = onPress;
    }
}
