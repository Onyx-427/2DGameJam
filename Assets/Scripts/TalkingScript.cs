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
    public bool paperIntro;
    private Scene currentScene;
    private bool cutScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "BedScene" ) {introTalking = true;}
        if (currentScene.name == "BedScene" || currentScene.name == "GameEnd")
        {
            
            CamFade.instance.StartCoroutine(CamFade.instance.FadeBlackTo());
            playerSprite.SetActive(false);
            bedSprite.SetActive(true);
            StartCoroutine(waitonesec());
        }
        
        if (currentScene.name == "Game")
        {
            paperIntro = true;
            StartDialogue(new string[]
            {
                "What's that piece of paper over there?...",
                "I should go read it... (Press F to Interact)"
            });
        }
        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !cutScene)
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
            introTalking = false;
            SceneManager.LoadScene("Game");
        }
        if (paperIntro)
        {
            paperIntro = false;
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
    private IEnumerator waitonesec()
    {
        cutScene = true;
        yield return new WaitForSeconds(2);
        playerSprite.SetActive(true);
        bedSprite.SetActive(false);
        bedSprite2.SetActive(true);
        talkingUI.SetActive(true);
        cutScene = false;
        StartDialogue(new string[]
        {
            "Ugh, where am I?... (Press SPACE to continue)",
            "I have such a bad headache...",
            "My memory's all fuzzy...",
            "I guess I should get out of this room to explore... "
        });
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        GameState.gameEnded = true;
        SceneManager.LoadScene("GameEnd");
    }
}
