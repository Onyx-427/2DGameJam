using System.Linq.Expressions;
using JetBrains.Annotations;
using UnityEngine;

public class ArcadeInteraction : MonoBehaviour, IInteractable
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
            talkingScript.StartDialogue( new string[] { "Ummmm..... wasn't there two arcade machines here? (" + PlayerInteraction.instance.interactionCount + "/ 5)" });
        }
        else
        {
            talkingScript.StartDialogue(new string[] { "Nice arcade machines... (" + PlayerInteraction.instance.interactionCount + "/ 10)" });
        }
    }

    public void GetInteractPrompt()
    {
        
    }
}
