using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class AnimateHandController : MonoBehaviour
{

    [SerializeField]
    InputActionReference gripInputAction;
    [SerializeField]
    InputActionReference triggerInputAction;

    Animator m_handAnimator;

    float m_gripValue;
    float m_triggerValue;

    // Start is called before the first frame update
    void Start()
    {
        m_handAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }

    private void AnimateGrip()
    {
        m_gripValue = gripInputAction.action.ReadValue<float>();
        m_handAnimator.SetFloat("Grip", m_gripValue);
    }

    private void AnimateTrigger()
    {
        m_triggerValue = triggerInputAction.action.ReadValue<float>();
        m_handAnimator.SetFloat("Trigger", m_triggerValue);
    }
}
