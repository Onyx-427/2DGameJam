using UnityEngine;

public class ScaryTeddyInteractable : MonoBehaviour, IInteractable
{
    public bool isInteracted;
    public bool IsInteracted => isInteracted;
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
        if (propDecay.spriteChanged && EnemyManager.instance.majorChanges)
        {
            talkingScript.StartDialogue(new string[] { "OH MY- WHAT THE HELL IS THAT... there's something wrong here, this was NOT here before... (" + PlayerInteraction.instance.interactionCount + "/ 5)" });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
