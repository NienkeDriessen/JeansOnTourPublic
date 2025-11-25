using UnityEngine;
using UnityEngine.UI;

public class PuzzleTextManager : MonoBehaviour
{
    // UI components for puzzle text
    public Text puzzleExplanationText;
    public Button cutButton;
    public Button againButton;
    public Text fabricSavedText;

    private LanguageManager languageManager;  

    private void Start()
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
        // Set text values based on keys in the JSON file
        UpdatePuzzleTexts();
    }

    private void UpdatePuzzleTexts()
    {
        // Set the text for puzzle explanation, cut button, again button, and fabric saved
        puzzleExplanationText.text = languageManager.GetLocalizedValue("puzzel_uitleg");
        cutButton.GetComponentInChildren<Text>().text = languageManager.GetLocalizedValue("puzzel_cut");
        againButton.GetComponentInChildren<Text>().text = languageManager.GetLocalizedValue("puzzel_again");
        fabricSavedText.text = languageManager.GetLocalizedValue("puzzel_bespaard");
    }
}
