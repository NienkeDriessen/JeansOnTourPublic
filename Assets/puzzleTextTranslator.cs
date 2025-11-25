using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class puzzleTextTranslator : MonoBehaviour
{
    public TextMeshProUGUI cutButton;
    public TextMeshProUGUI againButton;
    public TextMeshProUGUI fabricSaved;
    public TextMeshProUGUI puzzleExplanation;

    private LanguageManager languageManager;
    // Start is called before the first frame update
    void Start()
    {
        // Load LanguageManager instance
        if (LanguageManager.Instance == null)
        {
            Debug.LogError("LanguageManager not found!");

        }
        else
        {
            languageManager = LanguageManager.Instance;
            Debug.Log("LanguageManager found! language = " + languageManager.currentLanguage);
            UpdatePuzzleTexts();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdatePuzzleTexts()
    {

        // Set the text for puzzle explanation, cut button, again button, and fabric saved
        puzzleExplanation.text = languageManager.GetLocalizedValue("puzzel_uitleg");

        // Set the text of the button to the corresponding answer from QnA.answers
        cutButton.text = languageManager.GetLocalizedValue("puzzel_cut");

        againButton.text = languageManager.GetLocalizedValue("puzzel_again");

        fabricSaved.text = languageManager.GetLocalizedValue("puzzel_bespaard");
    }
}
