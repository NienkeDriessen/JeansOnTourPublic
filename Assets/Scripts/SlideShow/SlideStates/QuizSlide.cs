using System;
using UnityEngine;

public class QuizSlide : Slide<QuizState>
{
    public override void OnSlideStateChanged()
    {
        GameObject quizManagerObject = GameObject.Find("QuizManager");
        QuizManager QuizManager = quizManagerObject.GetComponent<QuizManager>();

        switch (GetCurrentState())
        {
            case QuizState.INITIAL:
                RestartSlide();
                break;
            case QuizState.ANSWERING:
                break;
            case QuizState.SHOW_ANSWERS:
                QuizManager.CheckVotes();
                break;
            default:
                throw new Exception();
        }
    }
}

public enum QuizState
{
    INITIAL = 0,
    ANSWERING = 1,
    SHOW_ANSWERS = 2
}