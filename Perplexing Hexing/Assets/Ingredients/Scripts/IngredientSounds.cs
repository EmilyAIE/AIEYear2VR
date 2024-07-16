using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSounds : MonoBehaviour
{
    AudioSource m_audio;
    [SerializeField]
    AudioClip m_pickUp, m_thud;

    public void PickUpNoise()
    {
        m_audio.PlayOneShot(m_pickUp);
    }

    public void ThudNoise()
    {
        m_audio.PlayOneShot(m_thud);
    }
}
