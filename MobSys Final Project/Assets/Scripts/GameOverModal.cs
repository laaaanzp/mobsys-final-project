using UnityEngine;

public class GameOverModal : MonoBehaviour
{
    private static GameOverModal instance;

    
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

    public static void Restart()
    {
        Close();
        Database.Restart();
        SceneSwitcher.LoadScene(SceneIndex.LEVEL);
    }

    public static void MainMenu()
    {
        Close();
        SceneSwitcher.LoadScene(SceneIndex.MAIN_MENU);
    }
}
