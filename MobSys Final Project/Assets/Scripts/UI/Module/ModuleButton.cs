using UnityEngine;

public class ModuleButton : MonoBehaviour
{
    [SerializeField] private GameObject highlightObject;
    [SerializeField] private CanvasGroup highlightText;
    private static ModuleButton instance;

    void Awake()
    {
        instance = this;
    }

    private bool isEnabled;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (isEnabled)
                Unhighlight();
            else
                Highlight();

            isEnabled = !isEnabled;
        }
    }

    public void OnPress()
    {
        ModuleModal.Open();
        AudioPlayer.PlayModuleOpen();
    }

    public static void Highlight()
    {
        instance.highlightObject.SetActive(true);
        instance.highlightObject.LeanScale(new Vector3(1.1f, 1.1f, 1f), 0.5f).setLoopPingPong();

        instance.highlightText.LeanAlpha(1f, 0.5f);
    }

    public static void Unhighlight()
    {
        instance.highlightObject.SetActive(false);
        instance.highlightObject.LeanCancel();
        instance.highlightObject.transform.localScale = new Vector3(0.7f, 0.7f, 1f);

        instance.highlightText.alpha = 0f;
    }
}
