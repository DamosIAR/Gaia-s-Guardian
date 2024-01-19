using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [Header("ChoicesUI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicestext;

    private Story currentStory;

    public bool dialogueIsPlaying;

    private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicestext = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicestext[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    public void enterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying =true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false );
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            //set text for current dialogue line
            dialogueText.text = currentStory.Continue();
            //display choices if any, for this dialogue line
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentchoices = currentStory.currentChoices;

        if(currentchoices.Count > choices.Length)
        {
            //debug.LogError("more choices given than the UI can support. Number of choices given: " + currentchoices.Count);
        }

        int index = 0;
        foreach(Choice choice in currentchoices)
        {
            choices[index].gameObject.SetActive(true);
            choicestext[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);

    }
}
