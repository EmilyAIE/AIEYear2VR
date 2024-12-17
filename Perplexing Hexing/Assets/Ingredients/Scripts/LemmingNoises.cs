using UnityEngine;

public class LemmingNoises : MonoBehaviour
{
    AudioSource m_audio;

    [SerializeField]
    AudioClip m_grabNoise, m_throwNoise, m_drownNoise;

    [Range(0, 1)] public float GrabVol;
    [Range(0, 1)] public float ThrowVol;

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    public void PlayGrabNoise()
    {
        float pitchAdjust = Random.Range(0.7f, 1.3f);
        m_audio.pitch = pitchAdjust;
        m_audio.PlayOneShot(m_grabNoise, GrabVol);
    }

    public void PlayThrowNoise()
    {
        m_audio.Stop();
        m_audio.PlayOneShot(m_throwNoise, ThrowVol);
    }

    public AudioClip GetDrowningLemming()
    {
        return m_drownNoise;
    }
}
