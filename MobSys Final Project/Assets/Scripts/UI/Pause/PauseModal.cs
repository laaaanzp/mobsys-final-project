using UnityEngine;

public class PauseModal : MonoBehaviour
{
    private static PauseModal instance;


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

    public static void MainMenu()
    {
        Close();
        SceneSwitcher.LoadScene(SceneIndex.MAIN_MENU);
    }

    void OnEnable()
    {
        Time.timeScale = 0f;
    }

    void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
