using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronFlame : MonoBehaviour
{
    Cauldron m_cauldron;
    AudioSource m_audio;
    public GameObject FlameObject;
    public GameObject FlameLight;
    public AudioClip FlameWoosh;

    private void Start()
    {
        m_cauldron = GetComponentInParent<Cauldron>();
        m_audio = GetComponent<AudioSource>();
    }

    public void StartCooking()
    {
        m_cauldron.StartCooking();
        m_audio.PlayOneShot(FlameWoosh);
        m_audio.Play();
        FlameObject.SetActive(true);
        FlameLight.SetActive(true);

    }

    public void StopCooking()
    {
        m_audio.Stop();
        FlameObject.SetActive(false);
        FlameLight.SetActive(false);
    }
}
