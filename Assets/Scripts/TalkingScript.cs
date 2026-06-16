using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkingScript : MonoBehaviour, GameState
{
    public TextMeshProUGUI text;
    private bool showingText = false;
    [SerializeField] private float letterDelay = .1f;
    [SerializeField] private GameObject talkingUI;
    [SerializeField] private string[] lines;
    public bool introTalking;
    private int currentLine = 0;
    private Coroutine typingCoroutine;
    [SerializeField] private GameObject endText;
    [SerializeField] private GameObject playerSprite;
    [SerializeField] private GameObject bedSprite;
    [SerializeField] private GameObject bedSprite2;
    void Start()
    {
        playerSprite.SetActive(false);
        bedSprite.SetActive(true);
        bedSprite2.SetActive(false);
        introTalking = true;
        talkingUI.SetActive(true);
        StartDialogue(new string[]
        {
            "Ugh, where am I?... (Press SPACE to continue)",
            "I have such a bad headache...",
            "My memory's all fuzzy...",
            "Why am I still here?...",
            "I should go read the piece of paper over there... (WASD to move)"
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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

    public void EndDialogue()
    {
        text.text = "";
        talkingUI.SetActive(false);
        if (introTalking)
        {
            playerSprite.SetActive(true);
            bedSprite.SetActive(false);
            bedSprite2.SetActive(true);
            introTalking = false;
            
        }
        if (GameState.gameEnded)
        {
            CamFade.instance.StartCoroutine(CamFade.instance.FadeToBlack());
            if (endText != null)
            {
                endText.SetActive(true);
            }
        }
        if (PlayerInteraction.instance.interactionCount == 10)
        {
            EnemyManager.instance.firstChange();
            introTalking = true;
            PlayerInteraction.instance.interactionCount = 0;
            PlayerInteraction.instance.interactedObjects.Clear();
        }
        if (EnemyManager.instance != null)
        {
            if (EnemyManager.instance.smallChanges && PlayerInteraction.instance.interactionCount == 6)
            {
                introTalking = true;
                EnemyManager.instance.firstMajorChange();
                PlayerInteraction.instance.interactionCount = 0;
                PlayerInteraction.instance.interactedObjects.Clear();
            }
            if (EnemyManager.instance.majorChanges && PlayerInteraction.instance.interactionCount == 5)
            {
                introTalking = true;
                EnemyManager.instance.firstBloodChange();
                PlayerInteraction.instance.interactionCount = 0;
                PlayerInteraction.instance.interactedObjects.Clear();
            }
            if (EnemyManager.instance.bloodChanges && PlayerInteraction.instance.interactionCount == 1)
            {
                introTalking = true;
                EnemyManager.instance.firstShadowChange();
                PlayerInteraction.instance.interactionCount = 0;
                PlayerInteraction.instance.interactedObjects.Clear();
            }
            if (EnemyManager.instance.shadowChanges && PlayerInteraction.instance.interactionCount == 2)
            {
                introTalking = true;
                CamFade.instance.StartCoroutine(CamFade.instance.FadeToBlack());
                StartCoroutine(wait());



            }
        }

    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        GameState.gameEnded = true;
        SceneManager.LoadScene("GameEnd");
    }
}
