using UnityEngine;

public class LabPapersInteractable : MonoBehaviour, IInteractable
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
            talkingScript.StartDialogue( new string[] { "Hmmm... these papers look a lot more organized then they were before... maybe I'm just remembering them incorrectly" });
        }
        else
        {
            talkingScript.StartDialogue( new string[] { "Wow... looks like we worked so hard we forgot to clean up the lab..." });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
