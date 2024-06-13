using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float duration = 0.5f;
    private static SceneSwitcher instance;


    void Awake()
    {
        instance = this;
        canvasGroup.alpha = 1f;
        LeanTween.alphaCanvas(instance.canvasGroup, 0f, instance.duration);
    }

    public static void LoadScene(string sceneName)
    {
        instance.canvasGroup.blocksRaycasts = true;

        LeanTween.alphaCanvas(instance.canvasGroup, 1f, instance.duration)
            .setOnComplete(() => {
                SceneManager.LoadScene(sceneName);
                instance.canvasGroup.blocksRaycasts = false;
                LeanTween.alphaCanvas(instance.canvasGroup, 0f, instance.duration);
            });
    }

    public static void LoadScene(SceneIndex sceneIndex)
    {
        LoadScene((int)sceneIndex);
    }

    public static void LoadScene(int sceneId)
    {
        instance.canvasGroup.blocksRaycasts = true;

        LeanTween.alphaCanvas(instance.canvasGroup, 1f, instance.duration)
            .setOnComplete(() => {
                SceneManager.LoadScene(sceneId);
                instance.canvasGroup.blocksRaycasts = false;
                LeanTween.alphaCanvas(instance.canvasGroup, 0f, instance.duration);
            });
    }
}

public enum SceneIndex
{
    MAIN_MENU = 0,
    LEVEL = 1
}