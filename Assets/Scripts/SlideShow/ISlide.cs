using System;

public interface ISlide
{
    void OnNextButton();
    void OnPreviousButton();
    void OnRestartButton();
    void OnSlideInteraction();
    void OnSlideStateChanged();
    void SetHighScore(HighScore highScore);
}