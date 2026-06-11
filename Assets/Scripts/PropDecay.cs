using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PropDecay : MonoBehaviour
{
    private int interactionCount;
    public bool readyForChange = false;

    [SerializeField] private GameObject firstSprite;
    [SerializeField] private GameObject secondSprite;
    [SerializeField] private int spriteNum;


    private void Start()
    {

        firstSprite?.SetActive(true);
        secondSprite?.SetActive(false);

        interactionCount = 0;
        readyForChange = false;
    }
    

    public void ReadyForChange()
    {
        readyForChange = true;


    }



    public IEnumerator SpriteChange()
    {
        yield return new WaitForSeconds(2f);
        firstSprite?.SetActive(false);
        secondSprite?.SetActive(true);
    }
}
