using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private string moduleName;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite openedSprite;
    [SerializeField] private Interactable interactable;


    void Awake()
    {
        bool isOpened = Database.IsModuleUnlocked(moduleName);

        if (isOpened)
            SetOpened();
    }

    public void Open()
    {
        Database.SetModuleUnlocked(moduleName, true);
        PlayerMovement.SavePosition();

        SetOpened();
    }

    private void SetOpened()
    {
        spriteRenderer.sprite = openedSprite;
        interactable.isInteractable = false;
    }
}
