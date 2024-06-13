using System;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Database : MonoBehaviour
{
    [SerializeField] private string[] quizTitles;

    private static Database instance;

    void Awake()
    {
        instance = this;
    }

    private static int _Convert(bool value)
    {
        return Convert.ToInt32(value);
    }

    private static bool _Convert(int value)
    {
        return Convert.ToBoolean(value);
    }

    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public static void Restart()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Player-Life", 3);
        PlayerPrefs.Save();
    }

    public static bool IsModuleUnlocked(string moduleName)
    {
        int value = PlayerPrefs.GetInt($"Module-{moduleName}", 0);
        return _Convert(value);
    }

    public static void SetModuleUnlocked(string moduleName, bool value)
    {
        int valueInt = _Convert(value);
        PlayerPrefs.SetInt($"Module-{moduleName}", valueInt);
        PlayerPrefs.Save();
    }

    public static bool IsQuizFinished(string quizTitle)
    {
        int value = PlayerPrefs.GetInt($"Quiz-{quizTitle}", 0);
        return _Convert(value);
    }

    public static void SetQuizFinished(string quizTitle, bool value)
    {
        int valueInt = _Convert(value);
        PlayerPrefs.SetInt($"Quiz-{quizTitle}", valueInt);
        PlayerPrefs.Save();
    }

    public static bool HasFinishedAllQuiz()
    {
        foreach (string quizTitle in instance.quizTitles)
        {
            if (!IsQuizFinished(quizTitle)) return false;
        }

        return true;
    }

    public static bool HasPlayerData()
    {
        return PlayerPrefs.GetInt("Player-Life", 0) > 0;
    }

    public static int GetPlayerLife()
    {
        return PlayerPrefs.GetInt("Player-Life", 0);
    }

    public static void SetPlayerLife(int life)
    {
        PlayerPrefs.SetInt("Player-Life", life);
        PlayerPrefs.Save();
    }

    public static void AddPlayerLife()
    {
        int life = GetPlayerLife() + 1;
        PlayerPrefs.SetInt("Player-Life", life);
        PlayerPrefs.Save();
    }

    public static void RemovePlayerLife()
    {
        int life = GetPlayerLife() - 1;
        PlayerPrefs.SetInt("Player-Life", life);
        PlayerPrefs.Save();
    }

    public static Vector2 GetPlayerPosition(Vector2 defaultPos)
    {
        float x = PlayerPrefs.GetFloat("Player-X", defaultPos.x);
        float y = PlayerPrefs.GetFloat("Player-Y", defaultPos.y);

        return new Vector3(x, y);
    }

    public static void SetPlayerLocation(Vector2 position)
    {
        float x = position.x;
        float y = position.y;

        PlayerPrefs.SetFloat("Player-X", x);
        PlayerPrefs.SetFloat("Player-Y", y);
        PlayerPrefs.Save();
    }
}