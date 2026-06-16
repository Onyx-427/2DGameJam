using UnityEngine;

public class ShadowInteraction : MonoBehaviour, IInteractable
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
        if (propDecay.spriteChanged && EnemyManager.instance.shadowChanges)
        {
            if (PlayerInteraction.instance.interactionCount == 1)
            {
                propDecay.secondSprite.SetActive(false);
                talkingScript.StartDialogue (new string[] { "WHAT THE HELL WAS THAT... where did it go??? I swear I just saw a shadow...", "Another plush again...", "Except this time it's a shadow?...", "Why do I keep noticing them...", "It's so weird, I feel like I'm forgetting something...", "I feel like I'm going insane, is this even real? (" + PlayerInteraction.instance.interactionCount + "/ 2)" });
            }
            else
            {
                propDecay.secondSprite.SetActive(false);
                talkingScript.StartDialogue(new string[] { "WHAT THE- ANOTHER SHADOW???...", "wait... I remember now... ", "These plushes... are mine...", "The ones I used to play with... but ho- (" + PlayerInteraction.instance.interactionCount + "/ 2)" });
            }
        }
    }

    public void GetInteractPrompt()
    {

    }
}
