using System.Runtime.Serialization;
using UnityEngine;

public class PotionsInteractable : MonoBehaviour, IInteractable
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
            talkingScript.StartDialogue(new string[] { "Hmm... I think these potions changed... I must be remembering them wrong... (" + PlayerInteraction.instance.interactionCount + "/ 6)" });
        }
        else
        {
            talkingScript.StartDialogue(new string[] { "Wow... there's a lot of potions laid out... (" + PlayerInteraction.instance.interactionCount + "/ 10)" });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
