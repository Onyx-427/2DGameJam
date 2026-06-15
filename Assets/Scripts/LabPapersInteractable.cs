using UnityEngine;

public class LabPapersInteractable : MonoBehaviour, IInteractable
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
            talkingScript.StartDialogue( new string[] { "Hmmm... these papers look a lot more organized then they were before... maybe I'm just remembering them incorrectly (" + PlayerInteraction.instance.interactionCount + "/ 6)" });
        }
        else
        {
            talkingScript.StartDialogue( new string[] { "Wow... looks like we worked so hard we forgot to clean up the lab... (" + PlayerInteraction.instance.interactionCount + "/ 10)" });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
