using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class TalkingScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    private bool showingText = false;
    [SerializeField] private float letterDelay = .1f;
    [SerializeField] private GameObject talkingUI;
    

    void Awake()
    {
        talkingUI.SetActive(false);
    }

    void Update()
    {
    }

    public void ShowText(string message)
    {
        if (!showingText)
        {
            StartCoroutine(ShowTextRoutine(message));
        }
    }

    private IEnumerator ShowTextRoutine(string message)
    {
        talkingUI.SetActive(true);
        showingText = true;

        text.text = "";

        foreach (char letter in message)
        {
            text.text += letter;
            yield return new WaitForSeconds(letterDelay);
        }
    }
}
