using UnityEngine;

public class PinkTedInteractable : MonoBehaviour, IInteractable
{
    public bool isInteracted;
    [SerializeField] private TalkingScript talkingScript;
    [SerializeField] private PropDecay propDecay;
    public bool canInteract(GameObject interactor)
    {
        return true;
    }

    public void Interact(GameObject interactor)
    {
        isInteracted = !isInteracted;
        if (propDecay.spriteChanged)
        {
            talkingScript.StartDialogue( new string[] { "Uh... that's a little creepy, wasn't this teddy bear" });
        }
        else
        {
            talkingScript.StartDialogue( new string[] { "Cute teddy bears... " });
        }
    }

    public void GetInteractPrompt()
    {
        
    }

}
