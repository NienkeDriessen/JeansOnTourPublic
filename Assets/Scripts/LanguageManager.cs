using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance;
    private Dictionary<string, string> localizedText;
    public string currentLanguage = "dutch";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadLanguage(currentLanguage);
    }

    public void LoadLanguage(string language)
    {
        // Load the language file from Resources/Languages folder
        TextAsset languageFile = Resources.Load<TextAsset>("Languages/" + language);

        if (languageFile != null)
        {
            string dataAsJson = languageFile.text;  // Load the JSON content as string
            Debug.Log("Loaded JSON: " + dataAsJson);  // Debug log the raw JSON string

            // Deserialize into the LocalizedText class
            LocalizedText localizedData = JsonUtility.FromJson<LocalizedText>(dataAsJson);

            // Convert to dictionary
            localizedText = new Dictionary<string, string>();
            foreach (var entry in localizedData.entries)
            {
                localizedText[entry.key] = entry.value;
            }

            // Log keys for debugging
            if (localizedText != null && localizedText.Count > 0)
            {
                Debug.Log("JSON successfully parsed. Keys in the dictionary:");
                foreach (var key in localizedText.Keys)
                {
                    Debug.Log(key);  // Log each key found in the dictionary
                }
            }
            else
            {
                Debug.LogError("Error: localizedText is empty after parsing.");
            }
        }
        else
        {
            Debug.LogError("Cannot find language file: " + language + ".json in Resources/Languages/");
        }
    }

    public string GetLocalizedValue(string key)
    {
        if (localizedText != null && localizedText.ContainsKey(key))
        {
            return localizedText[key];
        }
        if(localizedText == null)
        {
            Debug.LogError("Localized text is null?");
        }
        return "Key not found: " + key;  // Return a default message if key is not found
    }

    public void ToggleLanguage()
    {
        currentLanguage = (currentLanguage == "dutch") ? "english" : "dutch";  // Toggle between Dutch and English
        LoadLanguage(currentLanguage);  // Reload the language after toggling
    }

    // Helper class for deserialization
    [System.Serializable]
    private class LocalizedText
    {
        public List<LocalizedEntry> entries;  // List to hold the entries

        [System.Serializable]
        public class LocalizedEntry
        {
            public string key;  // Key for localization
            public string value;  // Localized value
        }
    }
}
