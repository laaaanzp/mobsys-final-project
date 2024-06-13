using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string interactionName;
    public bool isInteractable = true;
    public UnityEvent onInteract;

    public void Interact()
    {
        onInteract?.Invoke();
    }
}
