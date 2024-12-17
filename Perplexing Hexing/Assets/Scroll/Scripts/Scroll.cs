using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using TMPro;

public class Scroll : MonoBehaviour
{
    private Animator animator;
    private Spline m_inSpline, m_outSpline;
    private float inDuration = 2f, outDuration = 2f, textFadeDuration = 0.5f;
    public List<TextMeshProUGUI> scrollText;
    private CanvasGroup canvasGroup;
    public AnimationCurve flyInTween, flyOutTween, textFadeTween;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();            
        canvasGroup = GetComponentInChildren<CanvasGroup>();
        canvasGroup.alpha = 0;        
    }

    public void EnterHutt()
    {
        animator.SetTrigger("RollUp");        
        Tween.Spline(m_inSpline, transform, 0, 1, true, inDuration, 1, flyInTween, Tween.LoopType.None, null, ArrivedInHut);
        
    }

    private void ArrivedInHut()
    {
        animator.SetTrigger("RollDown");
        Tween.CanvasGroupAlpha(canvasGroup, 1, textFadeDuration, 0.5f, textFadeTween);        
    }

    public void ExitHutt()
    {
        animator.SetTrigger("RollUp");
        Invoke("ExitHuttPartTwo", 1);
        Tween.CanvasGroupAlpha(canvasGroup, 0, textFadeDuration, 0, textFadeTween);        
    }

    private void ExitHuttPartTwo()
    {
        int len = m_outSpline.Anchors.Length - 1;
        m_outSpline.Anchors[len].transform.position = transform.position;
        Tween.Spline(m_outSpline, transform, 1, textFadeDuration, true, outDuration, 0, flyOutTween, Tween.LoopType.None, null, ArrivedOutside);
    }

    private void ArrivedOutside()
    {
        Destroy(this.gameObject);
    }

    public void AddIngredient(TextMeshProUGUI ingredient)
    {
        scrollText.Add(ingredient);
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    EnterHutt();
        //}
        //
        //if (Input.GetMouseButtonDown(1))
        //{
        //    ExitHutt();
        //}
    }

    public void SetSplines(Spline inSpline, Spline outSpline)
    {
        m_inSpline = inSpline;
        m_outSpline = outSpline;
        EnterHutt();
    }
}
