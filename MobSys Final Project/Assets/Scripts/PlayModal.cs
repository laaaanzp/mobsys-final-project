using UnityEngine;

public class PlayModal : MonoBehaviour
{
    private static PlayModal instance;

    void Awake()
    {
        instance = this;
        Close();
    }

    public static void Open()
    {
        instance.gameObject.SetActive(true);
    }

    public static void Close()
    {
        instance.gameObject.SetActive(false);
    }

    public static void Continue()
    {
        SceneSwitcher.LoadScene(SceneIndex.LEVEL);
    }

    public static void NewGame()
    {
        YesNoModalHandler.Open("Start Again?", Restart, null);
    }

    private static void Restart()
    {
        Database.Restart();
        SceneSwitcher.LoadScene(SceneIndex.LEVEL);
    }
}
