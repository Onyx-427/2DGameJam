using System;
using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform cameraSpawn;
    [SerializeField] private Transform playerSpawn;
    [SerializeField] private GameObject mainCam;
    private GameObject player;

    
    public bool canInteract(GameObject interactor)
    {
        return true;
    }

    public void Interact(GameObject interactor)
    {
        mainCam.transform.position = cameraSpawn.position;
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = playerSpawn.position;
        }
    }

    public string GetInteractPrompt()
    {
        return null;
    }
}
