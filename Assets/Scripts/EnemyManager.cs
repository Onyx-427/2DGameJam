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
    public int num;
    private GameObject pickedObj;
    public bool objectPicked = false;
    public static EnemyManager instance { get; private set; }
    private int propType;
    private void Awake()
    {
        instance = this;
        
        StartCoroutine(WaitToPickChange(obvProps, 45, 75));
    }

    private IEnumerator WaitToPickChange(List<GameObject> props, int min, int max)
    {
        if (props == obvProps) { propType = 1;  }
        if (props == smallProps) { propType = 0; }

        if (props.Count > 0)
        {
            objectPicked = false;
            Debug.Log("waiting to pick");
            yield return new WaitForSeconds(Random.Range(min, max));
            PickRandomObj(propType);
            StartCoroutine(WaitToPickChange(props, min, max));
        }
        else
        {
            Debug.Log("Done picking");
            objectPicked = true;
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
            }
        }
        
        

        obvProps.RemoveAt(num);
    }

}
