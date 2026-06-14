using UnityEngine;

public class ScaryTeddyInteractable : MonoBehaviour, IInteractable
{
    public bool isInteracted;
    [SerializeField] private TalkingScript talkingScript;
    [SerializeField] private PropDecay propDecay;
    public bool canInteract(GameObject interactor)
    {
        if (propDecay.spriteChanged)
        {
            return true;
        }
        return false;
    }
    public void Interact(GameObject interactor)
    {
        isInteracted = !isInteracted;
        if (propDecay.spriteChanged)
        {
            talkingScript.StartDialogue(new string[] { "OH MY- WHAT THE HELL IS THAT... there's something wrong here, this was NOT here before..." });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
