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
        talkingScript.StartDialogue(new string[] { "There's something really weird going on here... you should explore" });
    }

    public void GetInteractPrompt()
    {
        
    }
}
