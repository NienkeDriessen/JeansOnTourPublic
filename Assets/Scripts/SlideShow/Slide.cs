using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slide<TEnum> : MonoBehaviour, ISlide where TEnum : Enum
{
    protected bool Started = false;
    private int _slideState;
    public int SlideState
    {
        get { return _slideState; }
        set
        {
            _slideState = value;
            OnSlideStateChanged();
        }
    }

    public HighScore highScore;

    private void Awake()
    {
        SlideState = 0;
    }

    public void SetHighScore(HighScore highScore)
    {
        this.highScore = highScore;
    }

    public virtual void OnNextButton()
    {
        if (SlideState == GetInitialState<TEnum>() || SlideState == GetFinalState<TEnum>())
        {
            NextScene();
        }
        else
        {
            SlideState++;
        }
    }

    public virtual void OnPreviousButton()
    {
        if (SlideState == GetInitialState<TEnum>())
        {
            PreviousScene();
        }
        else
        {
            SlideState--;
        }
    }

    public virtual void OnRestartButton()
    {
        if (highScore != null)
        {
            highScore.Restart();
        }
        SceneManager.LoadScene(0);
    }

    public virtual void OnSlideInteraction()
    {
        if (SlideState == GetInitialState<TEnum>() && SlideState != GetFinalState<TEnum>())
        {
            SlideState++;
        }
        Started = true;
    }

    public virtual void OnSlideStateChanged()
    {
        Debug.Log("State has changed!" + GetCurrentState());
    }

    protected void RestartSlide()
    {
        if (Started)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    protected TEnum GetCurrentState()
    {
        return (TEnum)Enum.ToObject(typeof(TEnum), SlideState);
    }

    protected void NextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    protected void PreviousScene()
    {
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
    }

    protected int GetFinalState<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<int>().Max();
    }

    protected int GetInitialState<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<int>().Min();
    }

}