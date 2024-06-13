using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private Collider2D interactableCollider;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Interactable interactable))
        {
            interactableCollider = collider;
            InteractButton.Show(interactable);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (interactableCollider = collider)
        {
            InteractButton.Hide();
        }
    }
}
