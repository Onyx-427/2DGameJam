using TMPro;
using UnityEngine;

public class PaperInteractable : MonoBehaviour, IInteractable
{
    public bool isInteracted;
    [SerializeField] private TalkingScript talkingScript;

    public bool canInteract(GameObject interactor)
    {
        return true;
    }
    public void Interact(GameObject interactor)
    {
        isInteracted = !isInteracted;
        talkingScript.ShowText("Ugh I have such a bad headache, why am I still here? ... I should investigate.");
    }

    public void GetInteractPrompt()
    {
        
    }
}
