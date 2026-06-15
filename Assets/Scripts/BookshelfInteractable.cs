using UnityEngine;

public class BookshelfInteractable : MonoBehaviour, IInteractable
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
            talkingScript.StartDialogue(new string[] { "WOAH... THIS BOOKSHELF DEFINITELY FELL", "There's probably someone here I should keep investingating... " + PlayerInteraction.instance.interactionCount + "/ 5)" });
        }
        else
        {
            talkingScript.StartDialogue(new string[] { "Hmm... these bookshelves are full of potions and elixers (" + PlayerInteraction.instance.interactionCount + "/ 10)" });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
