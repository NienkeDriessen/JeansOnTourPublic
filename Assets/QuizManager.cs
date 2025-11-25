using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System;

public class QuizManager : MonoBehaviour
{
    public LanguageManager languageManager;
    //List of all questions and their answers
    public QuestionAndAnswers QnA;
    // Image of button of correct answer
    public Sprite correctAnswerSprite;
    public Sprite falseAnswerSprite;
    private Color correctTextColor = new Color(247f / 255f, 236f / 255f, 216f / 255f);
    //Buttons
    public Button[] options;
    Color green = new Color(0f / 255f, 155f / 255f, 119f / 255f);
    //counts
    public int[] counts;
    private Button buttonA;
    private Button buttonB;
    private Button buttonC;
    private Button buttonD;

    private Color originalColorA;
    private Color originalColorB;
    private Color originalColorC;
    private Color originalColorD;
    private Color answerColorA = new(201f / 255f, 242f / 255f, 223f / 255f);
    private Color answerColorB = new(201f / 255f, 242f / 255f, 223f / 255f);
    private Color answerColorC = new(201f / 255f, 242f / 255f, 223f / 255f);
    private Color answerColorD = new(201f / 255f, 242f / 255f, 223f / 255f);


    //reference to current question text
    public Text questionText;
    private bool overrideFade = false;  // Flag to control the override of fade effect

    public void Start()
    {

        // Load LanguageManager instance
        if (LanguageManager.Instance == null)
        {
            Debug.LogError("LanguageManager not found!");

        }
        else
        {
            languageManager = LanguageManager.Instance;
            Debug.Log("LanguageManager found! lang = " + languageManager.currentLanguage);

        }

        counts = new int[4] { 0, 0, 0, 0 };
        GenerateQuestion();
        buttonA = options[0];
        buttonB = options[1];
        buttonC = options[2];
        buttonD = options[3];
        // Get the original color of each button
        originalColorA = buttonA.GetComponent<Image>().color;
        originalColorB = buttonB.GetComponent<Image>().color;
        originalColorC = buttonC.GetComponent<Image>().color;
        originalColorD = buttonD.GetComponent<Image>().color;

        SetOnClick();
    }


    //method showing the correct answer
    public void Correct()
    {
        overrideFade = true;  // Set the flag to override the fade effect
        ResetButtonColors();  // Reset all button colors to white

        if (QnA.correctAnswer == 5)
        {
            foreach (var button in options)
            {
                button.image.sprite = correctAnswerSprite;
                TextMeshProUGUI buttonText = button.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                buttonText.color = correctTextColor;
            }
        }
        else
        {
            Button correctButton = options[QnA.correctAnswer - 1];
            correctButton.image.sprite = correctAnswerSprite;
            TextMeshProUGUI buttonText = correctButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            buttonText.color = correctTextColor;

            foreach (var button in options)
            {
                if (button != correctButton)
                {
                    button.image.sprite = falseAnswerSprite;
                }
            }
        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            // Get the TextMeshProUGUI component of the button
            TextMeshProUGUI buttonText = options[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            // Set the text of the button to the corresponding answer from QnA.answers
            buttonText.text = languageManager.GetLocalizedValue(QnA.answers[i]);
        }
    }

    void GenerateQuestion()
    {
        questionText.text = languageManager.GetLocalizedValue(QnA.question);
        SetAnswers();
    }

    public void CheckVotes()
    {
        DisableButtons();
        int maxCount = counts.Max();

        // Get indices of all elements equal to maxCount
        List<int> maxIndices = new List<int>();
        for (int i = 0; i < counts.Length; i++)
        {
            if (counts[i] == maxCount)
            {
                maxIndices.Add(i + 1); // Add 1 to convert to answer index
            }
        }
        bool isCorrect = maxIndices.Contains(QnA.correctAnswer); // Check if correct answer index is in maxIndices

        if (maxIndices.Count == 1 && isCorrect)
        {
            Debug.Log("CORRECT TOTAL");
        }
        else if (maxIndices.Count > 1 && isCorrect)
        {
            Debug.Log("PARTIALLY CORRECT");
        }
        else
        {
            Debug.Log("WRONG ANSWER");
        }
        Correct();
    }

    public void DisableButtons()
    {
        foreach (Button button in options)
        {
            // Remove all listeners attached to the onClick event of the button
            button.onClick.RemoveAllListeners();
            button.interactable = false;
        }
    }

    public void ResetButtonColors()
    {
        foreach (Button button in options)
        {
            // Reset the color of each button to its original color
            button.GetComponent<Image>().color = Color.white;
        }
    }

    private void SetOnClick()
    {
        for (int i = 0; i < options.Length; i++)
        {
            int currentIndex = i; // Store the current index in a local variable to avoid closure issues
            options[i].onClick.AddListener(() => Answer(currentIndex));
        }
    }
    public void Answer(int currentButtonIndex)
    {
        Debug.Log("Answer + " + currentButtonIndex);


        // Update counts and check answer
        counts[currentButtonIndex]++;
        Debug.Log("Count: " + counts[currentButtonIndex]);

        // Update the text of the button to display the count
        TextMeshProUGUI buttonText = options[currentButtonIndex].transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        buttonText.text = counts[currentButtonIndex].ToString();

    }

}
