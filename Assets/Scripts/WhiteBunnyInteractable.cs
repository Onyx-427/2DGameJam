using Unity.VisualScripting;
using UnityEngine;

public class WhiteBunnyInteractable : MonoBehaviour, IInteractable
{
    public bool isInteracted;
    public bool IsInteracted => isInteracted;
    [SerializeField] private TalkingScript talkingScript;
    [SerializeField] private PropDecay propDecay;
    public bool canInteract(GameObject interactor)
    {
        return (EnemyManager.instance.intro || (EnemyManager.instance.smallChanges && propDecay.spriteChanged));
    }
    public void Interact(GameObject interactor)
    {
        isInteracted = true;
        if (propDecay.spriteChanged && EnemyManager.instance.smallChanges)
        {
            talkingScript.StartDialogue( new string[] { "uhh.. didn't the plush look a little different before? (" + PlayerInteraction.instance.interactionCount + "/ 6)" });
        }
        else
        {
            talkingScript.StartDialogue( new string[] { "Cute bunny plush...", "Kind of a weird thing to leave here tho... (" + PlayerInteraction.instance.interactionCount + "/ 10)" });
        }
    }

    
    public void GetInteractPrompt()
    {

    }
}
