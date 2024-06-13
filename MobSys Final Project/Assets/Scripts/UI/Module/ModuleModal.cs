using UnityEngine;

public class ModuleModal : MonoBehaviour
{
    [SerializeField] ModuleContentController contentController;

    public static bool isOpened { get => instance.gameObject.activeInHierarchy; }
    private static ModuleModal instance;

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
}
