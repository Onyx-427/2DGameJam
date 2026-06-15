using UnityEngine;

public class BloodInteraction : MonoBehaviour, IInteractable
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
        if (propDecay.spriteChanged && EnemyManager.instance.bloodChanges)
        {
            propDecay.secondSprite.SetActive(false);
            talkingScript.StartDialogue( new string[] { "WHAT THE HELL WAS THAT... where did it go??? I swear I just saw blood... This isn't happening... It can't be happening." });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
