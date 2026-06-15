using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> obvProps;
    [SerializeField] private List<GameObject> smallProps;
    [SerializeField] private List <GameObject> shadowProps;
    [SerializeField] private List<GameObject> bloodProps;
    public int num;
    private GameObject pickedObj;
    public static EnemyManager instance { get; private set; }
    private int propType;
    private int smallChangeCount = 0;
    private int obvChangeCount = 0;
    private int bloodChangeCount = 0;
    public int shadowChangeCount = 0;

    public bool intro = true;
    public bool smallChanges = false;
    public bool majorChanges = false;
    public bool bloodChanges = false;
    public bool shadowChanges = false;
    [SerializeField] private TalkingScript talkingScript;
    private void Awake()
    {
        instance = this;
        intro = true;
    }

    public void firstChange()
    {
        intro = false;
        smallChanges = true;
        PickRandomObj(0);
        SoundManager.instance.PickRandomAudio();
        SoundManager.instance.PlayBGMusic(1);
        talkingScript.StartDialogue(new string[] {"What the hell was that???...",
        "Maybe I should explore around some more... (Interact with changes within the environemnt)"});
        StartCoroutine(WaitToPickChange(smallProps, 15, 30, 0));
    }
    public void firstMajorChange()
    {
        smallChanges = false;
        majorChanges = true;
        PickRandomObj(1);
        SoundManager.instance.PickRandomAudio();
        SoundManager.instance.PlayBGMusic(2);
        talkingScript.StartDialogue(new string[] {"There's more????...",
        "I need to get to the bottom of this... I feel like I'm going insane..."});
        StartCoroutine(WaitToPickChange(obvProps, 15, 30, 0));
    }
    public void firstBloodChange()
    {
        majorChanges = false;
        bloodChanges = true;
        talkingScript.StartDialogue(new string[] {"Okay this is getting ridiculous...", "who the hell is doing this... this has to be a prank, it cant't be real...",
        "There's got to be answers somewhere"});
        StartCoroutine(WaitToPickChange(bloodProps, 15, 30, 0));
    }
    public void firstShadowChange()
    {
        StopAllCoroutines();
        bloodChanges = false;
        shadowChanges = true;
        talkingScript.StartDialogue(new string[] {"OMG OMG OMG, WHAT DO I DO...", "This can't actually be real there's no way I just saw that",
        "I need to find someone to help me I need to get out of here but how??"});
        StartCoroutine(WaitToPickChange(shadowProps, 15, 30, 0));
    }
    private IEnumerator WaitToPickChange(List<GameObject> props, int min, int max, int minProps)
    {
        if (props == smallProps) { propType = 0; }
        if (props == obvProps) { propType = 1;  }
        if (props == bloodProps) { propType = 2; }
        if (props == shadowProps) { propType = 3; }

        if (props.Count > minProps)
        {
            Debug.Log("waiting to pick");
            yield return new WaitForSeconds(Random.Range(min, max));
            PickRandomObj(propType);
            StartCoroutine(WaitToPickChange(props, min, max, minProps));
        }
        else
        {
            Debug.Log("Done picking");
        }
    }


    private void PickRandomObj(int typeObj)
    {
        Debug.Log("Picking net obj in list");
        if (typeObj == 0)
        {
            num = Random.Range(0, smallProps.Count);
            pickedObj = smallProps[num];
            PropDecay decay = pickedObj.GetComponent<PropDecay>();
            if (decay != null)
            {
                SoundManager.instance.PickRandomAudio();
                decay.ReadyForChange();
                smallProps.RemoveAt(num);
                smallChangeCount++;
            }
        }
        if (typeObj == 1)
        {
            num = Random.Range(0, obvProps.Count);
            pickedObj = obvProps[num];
            PropDecay decay = pickedObj.GetComponent<PropDecay>();
            if (decay != null)
            {
                SoundManager.instance.PickRandomAudio();
                decay.StartCoroutine(decay.SpriteChange());
                obvProps.RemoveAt(num);
            }

        }
        if (typeObj == 2)
        {
            num = Random.Range(0, bloodProps.Count);
            pickedObj = bloodProps[num];
            PropDecay decay = pickedObj.GetComponent<PropDecay>();
            if (decay != null)
            {
                SoundManager.instance.PickRandomAudio();
                decay.StartCoroutine(decay.SpriteChange());
                bloodProps.RemoveAt(num);
                bloodChangeCount++;
            }
        }
        
        if (typeObj == 3)
        {
            num = Random.Range(0, shadowProps.Count);
            pickedObj = shadowProps[num];
            PropDecay decay = pickedObj.GetComponent<PropDecay>();
            if (decay != null)
            {
                SoundManager.instance.PickRandomAudio();
                decay.StartCoroutine(decay.SpriteChange());
                shadowProps.RemoveAt(num);
                shadowChangeCount++;
            }
        }
        
    }
    
}
