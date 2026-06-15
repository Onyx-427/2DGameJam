using UnityEngine;

public interface IInteractable
{
    bool IsInteracted { get; }
    bool canInteract(GameObject interactor);
    void Interact (GameObject interactor);

    void GetInteractPrompt();
}
