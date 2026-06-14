using UnityEngine;

public class PresentsInteractable : MonoBehaviour, IInteractable
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
            talkingScript.StartDialogue(new string[] { "Ok, this is getting really weird...  I could've swore that this table was a mess before." });
        }
        else
        {
            talkingScript.StartDialogue( new string[] {"This tables such a mess...  looks like we forgot to clean up after the party?"});
        }
    }

    public void GetInteractPrompt()
    {

    }
}
