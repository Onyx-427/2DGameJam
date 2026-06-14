using UnityEngine;

public class PotionsInteractable : MonoBehaviour, IInteractable
{
    public bool isInteracted;
    [SerializeField] private TalkingScript talkingScript;
    [SerializeField] private PropDecay propDecay;
    public bool canInteract(GameObject interactor)
    {
        return true;
    }
    public void Interact(GameObject interactor)
    {
        isInteracted = !isInteracted;
        if (propDecay.spriteChanged)
        {
            talkingScript.StartDialogue(new string[] { "Hmm... I think these potions changed... I must be remembering them wrong..." });
        }
        else
        {
            talkingScript.StartDialogue(new string[] { "Wow... there's a lot of potions laid out... " });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
