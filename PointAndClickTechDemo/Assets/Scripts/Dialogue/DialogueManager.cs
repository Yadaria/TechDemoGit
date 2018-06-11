using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    #region Singleton
    public static DialogueManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one intance of GameManager!");
            return;
        }
        instance = this;
    }
    #endregion

    public Text nameText;
    public Text dialogueText;

    public Queue<string> sentences;

    private Dialogue dialogue;


    public GameObject continueButton;
    public GameObject choice1Button;
    public GameObject choice2Button;
    public GameObject choice3Button;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        this.dialogue = dialogue;
        if (dialogue.name != null)
            nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        continueButton.SetActive(true);
        choice1Button.SetActive(false);
        choice2Button.SetActive(false);
        choice3Button.SetActive(false);


        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        if (dialogue != null && !dialogue.endDialogue)
        {
            //StartDialogue(dialogue.followingDialogues[0]);
            DisplayChoices();
        }
        else
        {
            Debug.Log("Dialogue ended.");
            //go back to main scene
            SceneManager.LoadScene("Klassenraum");
        }

    }

    void DisplayChoices()
    {
        //Debug.Log("fD.lenght " + dialogue.answers.Length);
        continueButton.SetActive(false);

        switch (dialogue.answers.Length)
        {
            case 0:
                break;
            case 1:
                choice1Button.SetActive(true);
                choice1Button.GetComponentInChildren<Text>().text = dialogue.answers[0].answerText;
                break;
            case 2:
                choice1Button.SetActive(true);
                choice2Button.SetActive(true);
                choice1Button.GetComponentInChildren<Text>().text = dialogue.answers[0].answerText;
                choice2Button.GetComponentInChildren<Text>().text = dialogue.answers[1].answerText;
                break;
            case 3:
                choice1Button.SetActive(true);
                choice2Button.SetActive(true);
                choice3Button.SetActive(true);
                choice1Button.GetComponentInChildren<Text>().text = dialogue.answers[0].answerText;
                choice2Button.GetComponentInChildren<Text>().text = dialogue.answers[1].answerText;
                choice3Button.GetComponentInChildren<Text>().text = dialogue.answers[2].answerText;
                break;
        }

    }

    public void StartNextDialogue(int index)
    {
        StartDialogue(dialogue.answers[index].nextDialogue);
    }

    private void Update()
    {
        if (dialogue == null) return;

        //Debug.Log(dialogueIndex + "arrayGrö0e: " + dialogue.followingDialogues.Length);
    }

}

[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;
    public bool endDialogue;

    [Header("Set only if 'End Dialogue' is false")]
    //public Dialogue[] dialogueChoices;
    //public string[] answers;
    public NextDialogue[] answers;
}

[System.Serializable]
public struct NextDialogue
{
    public string answerText;
    public Dialogue nextDialogue;
}
