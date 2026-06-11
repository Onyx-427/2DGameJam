using System.Collections;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactRange = 2f;
    [SerializeField] private LayerMask interactLayer;

    public IInteractable currentInteractable;
    private IInteractable lastInteractable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindInteractable();

        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            if (currentInteractable.canInteract(gameObject))
            {
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

            if (interactable != null)
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
        Debug.Log("Trigger exit with: " + other.name);
        if (other.CompareTag("Prop"))
        {
            PropDecay decay = other.GetComponent<PropDecay>();
            if (decay != null && decay.readyForChange)
            {
                Debug.Log("readyForChange = " + decay.readyForChange);
                Debug.Log("Sprite Changing");
                decay.StartCoroutine(decay.SpriteChange());
            }
            else
            {
                Debug.Log("No prop decay or not ready for change");
            }
            
        }
    }

}
