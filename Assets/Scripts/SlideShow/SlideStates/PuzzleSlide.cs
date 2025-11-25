using System;

public class PuzzleSlide : Slide<PuzzleState>
{

    public override void OnSlideStateChanged()
    {
        switch (GetCurrentState())
        {
            case PuzzleState.INITIAL:
                RestartSlide();
                break;
            case PuzzleState.PUZZLING:
                break;
            default:
                throw new Exception();
        }
    }

}

public enum PuzzleState
{
    INITIAL = 0,
    PUZZLING = 1
}