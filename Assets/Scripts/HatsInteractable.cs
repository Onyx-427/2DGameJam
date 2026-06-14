using System;
using UnityEngine;

public class HatsInteractable : MonoBehaviour, IInteractable
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
            talkingScript.StartDialogue( new string[] { "Huh... wasn't this table a little more messy before?" });
        }
        else
        {
            talkingScript.StartDialogue( new string[] { "This tables such a mess...  looks like we forgot to clean up after the party?" });
        }
    }

    public void GetInteractPrompt()
    {

    }
}
