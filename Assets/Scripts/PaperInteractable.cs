using TMPro;
using UnityEngine;

public class PaperInteractable : MonoBehaviour, IInteractable
{
    public bool isInteracted;
    public bool IsInteracted => isInteracted;
    [SerializeField] private TalkingScript talkingScript;

    public bool canInteract(GameObject interactor)
    {
        return EnemyManager.instance.intro;
    }
    public void Interact(GameObject interactor)
    {
        isInteracted = !isInteracted;
        talkingScript.StartDialogue(new string[] { "The paper says: 'There's something weird going on here. I don't know what's going on. It's like they're appearing out of nowhere'",
        "Uhhhhh... ok that's creepy...",
        "who's 'they'...",
        "maybe I should explore the building some more... (Press F to interact with objects)"});
    }

    public void GetInteractPrompt()
    {
        
    }
}
