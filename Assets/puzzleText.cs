using UnityEngine;
using UnityEngine.UI;

public class PuzzleText : MonoBehaviour
{
    // UI components for puzzle text
    public Text puzzleExplanationText;
    public Button cutButton;
    public Button againButton;
    public Text fabricSavedText;

    private LanguageManager languageManager;  // Assuming LanguageManager loads and manages localized text

    private void Start()
    {
        // Access LanguageManager instance
        languageManager = LanguageManager.Instance;

        if (languageManager == null)
        {
            Debug.LogError("LanguageManager instance not found!");
            return;
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
