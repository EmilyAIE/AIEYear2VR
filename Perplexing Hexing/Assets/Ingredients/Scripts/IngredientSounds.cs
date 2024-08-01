using UnityEngine;

public class IngredientSounds : MonoBehaviour
{
    AudioSource m_audio;
    [SerializeField]
    AudioClip m_pickUp, m_thud;

    [Range(0, 1)] public float PickUpVol;
    [Range(0, 1)] public float ThudVol;

    private void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    public void PickUpNoise()
    {
        m_audio.PlayOneShot(m_pickUp, PickUpVol);
    }

    public void ThudNoise()
    {
        m_audio.PlayOneShot(m_thud, ThudVol);
    }
}
