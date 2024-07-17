using UnityEngine;

public class LemmingNoises : MonoBehaviour
{
    AudioSource m_audio;

    [SerializeField]
    AudioClip m_grabNoise, m_throwNoise, m_drownNoise;

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    public void PlayGrabNoise()
    {
        m_audio.PlayOneShot(m_grabNoise);
    }

    public void PlayThrowNoise()
    {
        m_audio.PlayOneShot(m_throwNoise);
    }
}
