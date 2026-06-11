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
    private int num;
    private GameObject pickedObj;
    public static EnemyManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
        
        StartCoroutine(WaitToPickChange(smallProps, 45, 75));
    }

    private IEnumerator WaitToPickChange(List<GameObject> props, int min, int max)
    {
        if (props.Count > 0)
        {
            Debug.Log("waiting to pick");
            yield return new WaitForSeconds(Random.Range(min, max));
            PickRandomObj(1);
            StartCoroutine(WaitToPickChange(props, min, max));
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

        }
        if (typeObj == 1)
        {
            num = Random.Range(0, obvProps.Count);
            pickedObj = obvProps[num];
        }
        
        PropDecay decay = pickedObj.GetComponent<PropDecay>();
        if (decay != null)
        {
            decay.ReadyForChange();
        }

        obvProps.RemoveAt(num);
    }

}
