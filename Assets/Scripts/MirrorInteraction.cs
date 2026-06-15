using UnityEngine;

public class MirrorInteraction : MonoBehaviour, IInteractable
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
            talkingScript.StartDialogue( new string[] { "What the hell? I'm not going crazy, I remember the mirror not being broken! (" + PlayerInteraction.instance.interactionCount + "/ 5)" });
        }
        else
        {
            talkingScript.StartDialogue( new string[] { "Nice mirror... I look pretty today! (" + PlayerInteraction.instance.interactionCount + "/ 10)" });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
