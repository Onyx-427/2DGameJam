using System;
using UnityEngine;

public class HatsInteractable : MonoBehaviour, IInteractable
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
        isInteracted = !isInteracted;
        if (propDecay.spriteChanged && EnemyManager.instance.smallChanges)
        {
            talkingScript.StartDialogue( new string[] { "Huh... wasn't this table a little more messy before? (" + PlayerInteraction.instance.interactionCount + "/ 6)" });
        }
        else
        {
            talkingScript.StartDialogue( new string[] { "This tables such a mess...  looks like we forgot to clean up after the party? (" + PlayerInteraction.instance.interactionCount + "/ 10)" });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
