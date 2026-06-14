using UnityEngine;

public class ShadowInteraction : MonoBehaviour, IInteractable
{
    public bool isInteracted;
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
        if (propDecay.spriteChanged)
        {
            if (EnemyManager.instance.shadowChangeCount == 0)
            {
                talkingScript.StartDialogue (new string[] { "WHAT THE HELL WAS THAT... where did it go??? I swear I just saw a shadow... I feel like I'm going insane, is this even real?" });
            }
            else
            {
                talkingScript.StartDialogue(new string[] { "WHAT THE- ANOTHER SHADOW???... wait... I've seen that teddy before... that was my toy when I was a child... no... this has to be in my head... am i dreaming??... I.... I don't understa-" });
                EnemyManager.instance.StopAllCoroutines();
            }
        }
    }

    public void GetInteractPrompt()
    {

    }
}
