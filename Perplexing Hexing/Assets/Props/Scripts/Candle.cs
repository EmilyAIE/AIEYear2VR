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
        if (candleLight != null)
        {
            Tween.LightIntensity(candleLight, intensityTarget, lightLoopDuration, 0, lightTween, Tween.LoopType.Loop);
        }
        float rand = Random.Range(0, 3f);
        float delay = Random.Range(0, 3f);
        Tween.LocalPosition(transform, targetPos, loopDuration + rand, delay, positionTween, Tween.LoopType.Loop);
        
    }

}
