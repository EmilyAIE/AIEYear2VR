using UnityEngine;
using Pixelplacement;

public class RecipeScroll : MonoBehaviour
{
    public Spline enterSpline, exitSpline;
    public AnimationCurve enterTween, exitTween;
    public float enterDuration, exitDuration;


    public void EnterRoom()
    {
        Tween.Spline(enterSpline, transform, 0, 1, true, enterDuration, 0, enterTween, Tween.LoopType.None, null, EnterRoomComplete);
    }

    private void EnterRoomComplete()
    {
        Debug.Log("You have arrived");
    }

    public void ExitRoom()
    {
        Tween.Spline(exitSpline, transform, 0, 1, true, exitDuration, 0, exitTween, Tween.LoopType.None, null, ExitRoomComplete);
    }

    private void ExitRoomComplete()
    {
        Debug.Log("You have exited");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            EnterRoom();
        }
    }
}
