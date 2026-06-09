using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Prop"))
        {
            PlayerInteractionUI.instance.StartCoroutine(PlayerInteractionUI.instance.OpenUI());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Prop"))
        {
            PlayerInteractionUI.instance.StartCoroutine(PlayerInteractionUI.instance.CloseUI());
        }
    }
}
