using UnityEngine;

public interface IInteractable
{
    bool canInteract(GameObject interactor);
    void Interact (GameObject interactor);

    void GetInteractPrompt();
}
