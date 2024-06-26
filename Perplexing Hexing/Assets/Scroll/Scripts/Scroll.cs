using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class Scroll : MonoBehaviour
{
    private Animator animator;
    private Spline inSpline, outSpline;
    private float inDuration = 2f, outDuration = 2f;
    public AnimationCurve flyInTween, flyOutTween;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        inSpline = GameObject.FindGameObjectWithTag("InSpline").GetComponent<Spline>();
        outSpline = GameObject.FindGameObjectWithTag("OutSpline").GetComponent<Spline>();
    }

    public void EnterHutt()
    {
        animator.SetTrigger("RollUp");
        Tween.Spline(inSpline, transform, 0, 1, true, inDuration, 1, flyInTween, Tween.LoopType.None, null, ArrivedInHut);
    }

    private void ArrivedInHut()
    {
        animator.SetTrigger("RollDown");
    }

    public void ExitHutt()
    {
        animator.SetTrigger("RollUp");
        Invoke("ExitHuttPartTwo", 1);
    }

    private void ExitHuttPartTwo()
    {
        int len = outSpline.Anchors.Length - 1;
        outSpline.Anchors[len].transform.position = transform.position;
        Tween.Spline(outSpline, transform, 1, 0, true, outDuration, 0, flyOutTween, Tween.LoopType.None, null, ArrivedOutside);
    }

    private void ArrivedOutside()
    {
        animator.SetTrigger("RollDown");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EnterHutt();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ExitHutt();
        }
    }
}
