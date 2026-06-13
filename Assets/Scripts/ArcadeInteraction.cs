using UnityEngine;

public class ArcadeInteraction : MonoBehaviour, IInteractable
{
    public bool isInteracted;
    [SerializeField] private TalkingScript talkingScript;

    public bool canInteract(GameObject interactor)
    {
        return true;
    }
    public void Interact(GameObject interactor)
    {
        isInteracted = !isInteracted;
        if (EnemyManager.instance.objectPicked && EnemyManager.instance.num == 0)
        {
            talkingScript.ShowText("Ummmm..... wasn't there two arcade machines here?");
        }
        else
        {
            talkingScript.ShowText("Nice arcade machines... ");
        }
    }

    public void GetInteractPrompt()
    {

    }
}
