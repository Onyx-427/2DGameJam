using UnityEngine;

public class WhiteBunnyInteractable : MonoBehaviour, IInteractable
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
            talkingScript.StartDialogue( new string[] { "uhh.. didn't the plush look a little different before?" });
        }
        else
        {
            talkingScript.StartDialogue( new string[] { "Cute bunny plush... " });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
