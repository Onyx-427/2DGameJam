using UnityEngine;

public class PresentsInteractable : MonoBehaviour, IInteractable
{
    public bool isInteracted;
    public bool IsInteracted => isInteracted;
    [SerializeField] private TalkingScript talkingScript;
    [SerializeField] private PropDecay propDecay;
    public bool canInteract(GameObject interactor)
    {
        return (EnemyManager.instance.intro || (EnemyManager.instance.majorChanges && propDecay.spriteChanged));
    }
    public void Interact(GameObject interactor)
    {
        isInteracted = !isInteracted;
        if (propDecay.spriteChanged && EnemyManager.instance.majorChanges)
        {
            talkingScript.StartDialogue(new string[] { "WHAT... ", "DUDE THERE WAS DEFINITELY A PILE OF PRESENTS HERE WHAT'S GOING ON RIGHT NOW...", "I'm starting to freak out now... (" + PlayerInteraction.instance.interactionCount + "/ 5)" });
        }
        else
        {
            talkingScript.StartDialogue( new string[] { "That's odd, it looks like the birthday boy forgot to take his presents? (" + PlayerInteraction.instance.interactionCount + "/ 10)" });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
