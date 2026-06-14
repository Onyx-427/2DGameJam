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
    private void Awake()
    {
        instance = this;
        
        StartCoroutine(WaitToPickChange(smallProps, 30, 60, 0));
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
            if (propType == 0)
            {
                StartCoroutine(WaitToPickChange(obvProps, 45, 75, 0));
            }
            if (propType == 1)
            {
                StartCoroutine(WaitToPickChange(bloodProps, 45, 75, 0));
            }
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
                decay.StartCoroutine(decay.SpriteChange());
                shadowProps.RemoveAt(num);
                shadowChangeCount++;
            }
        }
        
    }

    public void StartShadowProps()
    {
        StopCoroutine(WaitToPickChange(bloodProps, 45, 75, 0));
        StartCoroutine(WaitToPickChange(shadowProps, 45, 75, 0));
    }
}
