using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI messageText;

    private static DialogueController instance;
    private static Queue<string> messages;
    private static Action onFinish;


    void Awake()
    {
        instance = this;
        Close();
    }

    public static void Open(string name, string[] messages, Action onFinish)
    {
        DialogueController.messages = new Queue<string>(messages);
        DialogueController.onFinish = onFinish;

        instance.nameText.text = name;
        instance.NextMessage();

        instance.gameObject.SetActive(true);
    }

    public static void Open(string name, string message, Action onFinish)
    {
        Open(name, new string[]{ message }, onFinish);
    }

    public static void Open(string name, string[] messages)
    {
        Open(name, messages, null);
    }
    public static void Open(string name, string message)
    {
        Open(name, message, null);
    }

    public static void Close()
    {
        instance.gameObject.SetActive(false);
    }

    public void NextMessage()
    {
        if (messages.TryDequeue(out string message))
        {
            instance.messageText.text = message;
        }
        else
        {
            Close();

            onFinish?.Invoke();
            onFinish = null;
        }
    }
}