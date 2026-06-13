using UnityEngine;

public class PropInteraction : MonoBehaviour, IInteractable
{
    public bool canInteract(GameObject interactor)
    {
        return true;
    }

    public void Interact(GameObject interactor)
    {
        //some ui stuff maybe
    }

    public void GetInteractPrompt()
    {
        
    }

}
