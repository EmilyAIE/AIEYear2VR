using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSounds : MonoBehaviour
{
    AudioSource m_audio;
    [SerializeField]
    AudioClip m_pickUp;

    public void PickUpNoise()
    {
        m_audio.PlayOneShot(m_pickUp);
    }
}
