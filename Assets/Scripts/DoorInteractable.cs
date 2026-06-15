using System;
using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    public bool isInteracted;
    public bool IsInteracted => isInteracted;
    [SerializeField] private Transform cameraSpawn;
    [SerializeField] private Transform playerSpawn;
    [SerializeField] private GameObject mainCam;
    [SerializeField] private Camera cam;
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
        if (gameObject.name == "MainDoorL")
        {
            cam.orthographicSize = 6.7f;
        }
        if (gameObject.name == "Party-Main" || gameObject.name == "BR-Main")
        {
            cam.orthographicSize = 4.5f;
        }
        if (gameObject.name == "MainDoorR")
        {
            cam.orthographicSize = 7.7f;
        }
    }

    public void GetInteractPrompt()
    {
        
    }
}
