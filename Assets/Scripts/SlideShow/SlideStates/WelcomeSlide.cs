using System;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeSlide : Slide<WelcomeState>
{
    public Text welcomeText;               // Reference to the Text component
    public Button languageToggleButton;      // Reference to the Button component

    void Start()
    {
        UpdateText();  // Update the text on startup
        languageToggleButton.onClick.AddListener(ToggleLanguage); // Attach ToggleLanguage method to the button
    }
    void Update()
    {
        // Check if the "L" key is pressed
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleLanguage(); // Call ToggleLanguage method when "L" is pressed
        }
    }

    // Method to update the welcome text
    void UpdateText()
    {
        welcomeText.text = LanguageManager.Instance.GetLocalizedValue("welcome_message");
        Debug.Log("Updating text");
    }

    // Method to toggle the language
    void ToggleLanguage()
    {
        Debug.Log("Toggling language");
        LanguageManager.Instance.ToggleLanguage(); // Call the language toggle method
        UpdateText();  // Update the text after toggling
    }
}


public enum WelcomeState
{
    INITIAL = 0
}