using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UICupboard : MonoBehaviour
{
    public GameObject textWithGrave, textWithoutGrave;
    public InputField inputField;
    public Button button;

    public string correctAnswer;
    public static bool isAnswerCorrect = false;

    // Use this for initialization
    void Start()
    {
        if (GameManager.graveVisited)
        {
            textWithGrave.SetActive(true);
            textWithoutGrave.SetActive(false);
        }
        else
        {
            textWithGrave.SetActive(false);
            textWithoutGrave.SetActive(true);
        }
    }

    public void CheckAnswer()
    {
        if (inputField.text == correctAnswer)
        {
            isAnswerCorrect = true;
        }
        SceneManager.LoadScene("Klassenraum");
    }
}
