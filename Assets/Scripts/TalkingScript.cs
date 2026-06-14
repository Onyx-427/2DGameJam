using System.Collections;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class TalkingScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    private bool showingText = false;
    [SerializeField] private float letterDelay = .1f;
    [SerializeField] private GameObject talkingUI;
    [SerializeField] private string[] lines;
    private bool introTalking;

    private int currentLine = 0;
    private Coroutine typingCoroutine;

    void Start()
    {
        talkingUI.SetActive(true);
        StartDialogue(new string[]
        {
            "Ugh, where am I?...",
            "I have such a bad headache...",
            "My memory's all fuzzy...",
            "Why am I still here?...",
            "I should go read the piece of paper over there... (WASD to move)"
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AdvanceDialogue();
        }
    }

    public void StartDialogue(string[] message)
    {
        currentLine = 0;
        lines = message;
        ShowText();
    }

    private void AdvanceDialogue()
    {
        if (showingText)
        {
            FinishCurrentLine();
        }
        else
        {
            currentLine++;

            if (currentLine < lines.Length)
            {
                ShowText();
            }
            else
            {
                EndDialogue();
            }
        }
    }
    private void ShowText()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(ShowTextRoutine(lines[currentLine]));
    }

    private IEnumerator ShowTextRoutine(string message)
    {
        talkingUI.SetActive(true);
        showingText = true;

        text.text = message;
        text.maxVisibleCharacters = 0;

        for (int i = 0; i <= message.Length; i++)
        {
            text.maxVisibleCharacters = i;
            yield return new WaitForSeconds(letterDelay);
        }
        showingText = false;
    }

    private void FinishCurrentLine()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        text.maxVisibleCharacters = lines[currentLine].Length;
        showingText = false;
    }

    private void EndDialogue()
    {
        text.text = "";
        talkingUI.SetActive(false);
    }
}
