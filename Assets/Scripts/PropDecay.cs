using Unity.VisualScripting;
using UnityEngine;

public class PropDecay : MonoBehaviour
{
    private int interactionCount;

    private void Start()
    {
        interactionCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionCount++;
            Decay();
        }
    }

    private void Decay()
    {
        Debug.Log(interactionCount);
    }
}
