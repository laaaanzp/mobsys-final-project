using UnityEngine;

[CreateAssetMenu]
public class QuizData : ScriptableObject
{
    public string question;
    public string choiceA;
    public string choiceB;
    public string choiceC;
    public string choiceD;
    public CorrectAnswer correctAnswer;
}

public enum CorrectAnswer
{
    A, B, C, D
}
