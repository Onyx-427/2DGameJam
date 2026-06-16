using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instance;
    [SerializeField] private float interactRange = 2f;
    [SerializeField] private LayerMask interactLayer;

    public IInteractable currentInteractable;
    public IInteractable lastInteractable;
    public int interactionCount = 0;
    [SerializeField] private TalkingScript talkingScript;
    public HashSet<GameObject> interactedObjects = new HashSet<GameObject>();

    [SerializeField] private AudioSource pickupSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        FindInteractable();

        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            
            GameObject interactableObject = ((MonoBehaviour)currentInteractable).gameObject;

            if (currentInteractable.canInteract(gameObject))
            {
                pickupSound.Play();

                if (interactableObject.CompareTag("Prop") && !interactedObjects.Contains(interactableObject))
                {
                    interactedObjects.Add(interactableObject);
                    interactionCount++;

                }
                
                currentInteractable.Interact(gameObject);
            }
        }

        
    }

    void FindInteractable()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange, interactLayer);

        currentInteractable = null;

        foreach (Collider2D hit in hits)
        {
            IInteractable interactable = hit.GetComponent<IInteractable>();

            if (interactable != null && interactable.canInteract(gameObject))
            {
                currentInteractable = interactable;
                break;
            }
        }

        if (currentInteractable != lastInteractable)
        {
            if (currentInteractable != null)
            {
                PlayerInteractionUI.instance.StartCoroutine(PlayerInteractionUI.instance.OpenUI());
            }
            else
            {
                PlayerInteractionUI.instance.StartCoroutine(PlayerInteractionUI.instance.CloseUI());
            }
            lastInteractable = currentInteractable;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Prop") && !talkingScript.introTalking)
        {
            talkingScript.EndDialogue();
        }
    }



}
