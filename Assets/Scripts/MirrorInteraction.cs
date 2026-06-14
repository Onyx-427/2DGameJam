using UnityEngine;

public class MirrorInteraction : MonoBehaviour, IInteractable
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
            talkingScript.StartDialogue( new string[] { "What the hell? I'm not going crazy, I remember the mirror not being broken!" });
        }
        else
        {
            talkingScript.StartDialogue( new string[] { "Nice mirror... I look pretty today!" });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
