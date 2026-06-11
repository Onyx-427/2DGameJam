using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> smallProps;

    public static EnemyManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
        
        StartCoroutine(WaitToPick());
    }


    private IEnumerator WaitToPick()
    {
        if (smallProps.Count > 0)
        {
            Debug.Log("waiting to pick");
            yield return new WaitForSeconds(Random.Range(30, 60));
            PickRandomObj();
            StartCoroutine(WaitToPick());
        }
        else
        {
            Debug.Log("Done picking");
        }
    }


    private void PickRandomObj()
    {

        Debug.Log("Picking net obj in list");
        int num = Random.Range(0, smallProps.Count);
        GameObject pickedObj = smallProps[num];

        PropDecay decay = pickedObj.GetComponent<PropDecay>();
        if (decay != null)
        {
            decay.ReadyForChange();
        }

        smallProps.RemoveAt(num);
    }
}
