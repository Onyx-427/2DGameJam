using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PropDecay : MonoBehaviour
{
    public bool readyForChange = false;
    public bool spriteChanged = false;
    public GameObject firstSprite;
    public GameObject secondSprite;
    //[SerializeField] private int spriteNum;


    private void Start()
    {

        firstSprite?.SetActive(true);
        secondSprite?.SetActive(false);

        readyForChange = false;
        spriteChanged = false;
    }
    

    public void ReadyForChange()
    {
        readyForChange = true;
        StartCoroutine(SpriteChange());

    }



    public IEnumerator SpriteChange()
    {
        yield return new WaitForSeconds(2f);
        firstSprite?.SetActive(false);
        secondSprite?.SetActive(true);
        spriteChanged = true;
    }
}
