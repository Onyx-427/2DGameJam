using UnityEngine;

public class BookshelfInteractable : MonoBehaviour, IInteractable
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
            talkingScript.StartDialogue(new string[] { "WOAH... okay when did this bookshelf fall... this is getting creepy now..." });
        }
        else
        {
            talkingScript.StartDialogue(new string[] { "Hmm... these bookshelves are full of potions and elixers" });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
