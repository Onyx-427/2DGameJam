using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractionUI : MonoBehaviour
{
    [SerializeField] private Vector2 uiOffset;
    [SerializeField] private Image uiImage;
    [SerializeField] private TextMeshProUGUI uiText;
    private bool UIOpened = false;
    public static PlayerInteractionUI instance { get; private set; }

    void Start()
    {
        UIOpened = false;
        instance = this;
        Color c = uiImage.color;
        Color t = uiText.color;
        c.a = 0;
        t.a = 0;
        uiImage.color = c;
        uiText.color = t;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }

    public IEnumerator OpenUI()
    {
        if (!UIOpened)
        {
            Color c = uiImage.color;
            Color t = uiText.color;
            float startAlpha = uiImage.color.a;
            float tStartAlpha = uiText.color.a;
            t.a = tStartAlpha;
            c.a = startAlpha;
            for (float i = 0; i < 1; i += .2f)
            {
                float newAlpha = Mathf.MoveTowards(startAlpha, 1, i);

                c.a = newAlpha;
                t.a = newAlpha;
                uiImage.color = c;
                uiText.color = t;
                yield return new WaitForSeconds(.05f);
            }
            UIOpened = true;
        }
    }

    public IEnumerator CloseUI()
    {
        Color c = uiImage.color;
        Color t = uiText.color;
        float startAlpha = uiImage.color.a;
        float tStartAlpha = uiText.color.a;
        t.a = tStartAlpha;
        c.a = startAlpha;

        for (float i = 0; i < 1f; i += .2f)
        {
            float newAlpha = Mathf.MoveTowards(startAlpha, 0, i);
            
            c.a = newAlpha;
            t.a = newAlpha;
            uiImage.color = c; 
            uiText.color = t;
            yield return new WaitForSeconds(.05f);

        }
        UIOpened = false;
    }
}
