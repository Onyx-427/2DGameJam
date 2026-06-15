using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CamFade : MonoBehaviour
{
    public static CamFade instance;

    [SerializeField] private GameObject imageObj;
    [SerializeField] private Image image;
    [SerializeField] private float fadeDur;
    private void Awake()
    {
        imageObj.SetActive(false);
        instance = this;
        StartCoroutine(FadeBlackTo());
    }
    public IEnumerator FadeToBlack()
    {
        Color color = image.color;
        imageObj.SetActive(true);

        float elapsed = 0;

        while (elapsed < fadeDur)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, elapsed / fadeDur);
            image.color = color;
            yield return null;
        }

        color.a = 1f;
        image.color = color;
        
    }

    public IEnumerator FadeBlackTo()
    {

        Color color = image.color;
        color.a = 1f;
        image.color = color;
        imageObj.SetActive(true);

        float elapsed = 0;

        while (elapsed < fadeDur)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, elapsed / fadeDur);
            image.color = color;
            yield return null;
        }

        
    }
}
