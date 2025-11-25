using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SlideManager : MonoBehaviour
{
    private ISlide CurrentSlide;
    public HighScore highScore;  // Reference to HighScore
    public LanguageManager languageManager;


    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        SetCurrentSlideType(scene.name);
    }

    private void Start()
    {
        // Load LanguageManager instance
        if (LanguageManager.Instance == null)
        {
            Debug.LogError("LanguageManager not found!");

        }
        else
        {
            Debug.Log("LanguageManager found!");
            languageManager = LanguageManager.Instance;
        }
    }

    private void SetCurrentSlideType(string sceneName)
    {
        GameObject slideManager = GameObject.Find("SlideManager");

        switch (sceneName)
        {
            case "Welcome":
                // Assume the WelcomeSlide is already attached in the Editor 
                CurrentSlide = slideManager.GetComponent<WelcomeSlide>();
                break;
            case "Puzzle":
                CurrentSlide = slideManager.AddComponent<PuzzleSlide>(); break;
            case "Quiz Q1":
                CurrentSlide = slideManager.AddComponent<QuizSlide>(); break;
            case "Quiz Q2":
                CurrentSlide = slideManager.AddComponent<QuizSlide>(); break;
            case "Quiz Q3":
                CurrentSlide = slideManager.AddComponent<QuizSlide>(); break;
            case "Video":
                CurrentSlide = slideManager.AddComponent<VideoSlide>(); break;
            default:
                throw new Exception();
        }

        
        CurrentSlide.SetHighScore(highScore);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            CurrentSlide.OnNextButton();
        }
        else if (Input.GetKeyDown(KeyCode.PageUp))
        {
            CurrentSlide.OnPreviousButton();
        }
        else if (Input.GetKeyDown(KeyCode.Period))
        {
            CurrentSlide.OnRestartButton();
        } else if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            CurrentSlide.OnSlideInteraction();
        }
    }
}