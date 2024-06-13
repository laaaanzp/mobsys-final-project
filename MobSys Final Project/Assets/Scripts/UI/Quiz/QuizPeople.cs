using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuizPeople : MonoBehaviour
{
    [SerializeField] private string topic;
    [SerializeField] private string peopleName;
    [SerializeField] private Interactable interactable;
    [SerializeField] private QuizData[] quizDatas;
    [SerializeField] private GameObject obstaclesContainer;

    private Queue<QuizData> quizDatasQueue;
    private int totalCorrect;
    private int totalQuestions;


    void Awake()
    {
        bool isQuizFinished = Database.IsQuizFinished(topic);
        interactable.isInteractable = !isQuizFinished;

        if (isQuizFinished)
        {
            RemoveObstacle();
        }

        totalQuestions = quizDatas.Length;
    }

    private void RemoveObstacle()
    {
        obstaclesContainer.SetActive(false);
    }

    public void OnInteract()
    {
        if (!Database.IsModuleUnlocked(topic))
        {
            DialogueController.Open(peopleName, $"Please acquire and read the page for {topic} first.");
            return;
        }

        PlayerMovement.SavePosition();

        string openingMessage;

        if (gameObject.name == "Rizal Park")
        {
            openingMessage = $"Hello there! You are in your final point of your destination and you must pass my questions first about {topic}.";
        }
        else
        {
            openingMessage = $"Hello there! In order to unlock this area, you have to pass my questions first about {topic}.";
        }

        DialogueController.Open(peopleName, new string[] { openingMessage, "In order to pass, you have to score atleast half of my questions.", "Are you ready? We shall start now!" }, OpenQuestions);
    }

    private void OpenQuestions()
    {
        quizDatasQueue = new Queue<QuizData>(quizDatas);
        totalCorrect = 0;
        NextQuestion();
    }

    private void NextQuestion()
    {
        if (quizDatasQueue.TryDequeue(out QuizData quizData))
        {
            QuizModal.Open(quizData, 
            () => { 
                totalCorrect++; 
                NextQuestion();
            },
            NextQuestion);
        }
        else
        {
            QuizModal.Close();
            int passing = Mathf.CeilToInt((float)totalQuestions / 2);

            string[] messages = new string[3];
            messages[0] = $"You scored {totalCorrect} out of {totalQuestions}.";

            if (passing > totalCorrect)
            {
                Life.Deduct();
                messages[1] = "That means you failed to pass my questions. You didn't pass atleast half of my questions.";
                messages[2] = "Try again next time. You can use the page you acquired from this area as your guide.";
            }
            else
            {
                if (gameObject.name == "Rizal Park")
                {
                    messages[1] = "That means you passed the final questions";
                    messages[2] = "You have finished your journey! Congratulations on reaching this point.";
                }
                else
                {
                    messages[1] = "That means you passed my questions and unlocked the next area";
                    messages[2] = "Goodluck on your journey!";
                }
                Database.SetQuizFinished(topic, true);
                interactable.isInteractable = false;
                RemoveObstacle();
            }

            if (Database.GetPlayerLife() > 0)
            {
                if (gameObject.name == "Rizal Park")
                {
                    Database.ClearData();
                    DialogueController.Open(peopleName, messages, GameCompleteModal.Open);
                }
                else
                {
                    DialogueController.Open(peopleName, messages);
                }
            }
            else
            {
                GameOverModal.Open();
            }
        }
    }
}
