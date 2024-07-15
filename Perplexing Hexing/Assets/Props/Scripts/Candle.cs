using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;


public class Candle : MonoBehaviour
{
    public AnimationCurve positionTween, lightTween;
    public Vector3 targetPos;
    public float loopDuration;
    public float intensityTarget, lightLoopDuration;
    private Light candleLight;

    private void OnEnable()
    {
        candleLight = GetComponentInChildren<Light>();
        Tween.LocalPosition(transform, targetPos, loopDuration, 0, positionTween, Tween.LoopType.Loop);
        Tween.LightIntensity(candleLight, intensityTarget, lightLoopDuration, 0, lightTween, Tween.LoopType.Loop);
    }

}
