using UnityEngine;

public class PinkTedInteractable : MonoBehaviour, IInteractable
{
    public bool isInteracted;
    public bool IsInteracted => isInteracted;
    [SerializeField] private TalkingScript talkingScript;
    [SerializeField] private PropDecay propDecay;
    public bool canInteract(GameObject interactor)
    {
        return EnemyManager.instance.intro || (EnemyManager.instance.smallChanges && propDecay.spriteChanged);
    }

    public void Interact(GameObject interactor)
    {
        isInteracted = !isInteracted;
        if (propDecay.spriteChanged && EnemyManager.instance.smallChanges)
        {
            talkingScript.StartDialogue( new string[] { "Uh... that's a little creepy, wasn't this teddy bear (" + PlayerInteraction.instance.interactionCount + "/ 6)" });
        }
        else
        {
            talkingScript.StartDialogue(new string[] { "Cute teddy bears...", "Seems like an awful lot of them... (" + PlayerInteraction.instance.interactionCount + "/ 10)" });
        }
    }

    public void GetInteractPrompt()
    {
        
    }

}
