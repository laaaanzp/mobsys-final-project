using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuizModal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuizChoicesController choicesController;

    private static QuizModal instance;


    void Awake()
    {
        instance = this;
        Close();
    }

    public static void Open(QuizData quizData, Action onPass, Action onFail)
    {
        instance.questionText.text = quizData.question;

        QuizChoiceData choiceDataA = new QuizChoiceData(quizData.choiceA, onFail);
        QuizChoiceData choiceDataB = new QuizChoiceData(quizData.choiceB, onFail);
        QuizChoiceData choiceDataC = new QuizChoiceData(quizData.choiceC, onFail);
        QuizChoiceData choiceDataD = new QuizChoiceData(quizData.choiceD, onFail);

        switch (quizData.correctAnswer)
        {
            case CorrectAnswer.A:
                choiceDataA.onPress = onPass;
                break;
            case CorrectAnswer.B:
                choiceDataB.onPress = onPass;
                break;
            case CorrectAnswer.C:
                choiceDataC.onPress = onPass;
                break;
            case CorrectAnswer.D:
                choiceDataD.onPress = onPass;
                break;
        }

        instance.choicesController.Initialize(choiceDataA, choiceDataB, choiceDataC, choiceDataD);
        instance.gameObject.SetActive(true);
    }

    public static void Close()
    {
        instance.gameObject.SetActive(false);
    }
}
