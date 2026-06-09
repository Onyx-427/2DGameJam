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
    public static PlayerInteractionUI instance { get; private set; }

    void Start()
    {
        instance = this;
        Color c = uiImage.color;
        c.a = 0;
        uiImage.color = c;
        uiText.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator OpenUI()
    {
        Color c = uiImage.color;
        Color t = uiText.color;
        float startAlpha = uiImage.color.a;
        float tStartAlpha = uiText.color.a;
        t.a = tStartAlpha;
        c.a = startAlpha;
        for (float i = 0; i <= 1; i += .1f)
        {
            float newAlpha = Mathf.Lerp(startAlpha, 0, i);

            c.a = i;
            uiImage.color = c;
            uiText.color = c;
            yield return new WaitForSeconds(.1f);
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

        for (float i = 0; i < 1f; i += .1f)
        {
            float newAlpha = Mathf.Lerp(startAlpha, 0, i);
            
            c.a = newAlpha;
            t.a = newAlpha;
            uiImage.color = c; 
            uiText.color = t;
            yield return new WaitForSeconds(.1f);

        }

    }
}
