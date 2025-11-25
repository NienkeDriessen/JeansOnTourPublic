using System;
using UnityEngine;

public class VideoSlide : Slide<VideoState>
{
    public override void OnSlideStateChanged()
    {
        GameObject videoManagerObject = GameObject.Find("VideoManager");
        VideoManager VideoManager = videoManagerObject.GetComponent<VideoManager>();
        switch (GetCurrentState())
        {
            case VideoState.INITIAL:
                RestartSlide();
                break;
            case VideoState.PLAYING:
                Started = true;
                VideoManager.PlayVideo();
                break;
            default:
                throw new Exception();
        }
    }

    public override void OnNextButton()
    {
        if (SlideState == GetFinalState<VideoState>())
        {
            NextScene();
        }
        else
        {
            SlideState++;
        }
    }

    public override void OnSlideInteraction()
    {
    }
}

public enum VideoState
{
    INITIAL = 0,
    PLAYING = 1
}