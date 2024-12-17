using UnityEngine;

public class CauldronFlame : MonoBehaviour
{
    Cauldron m_cauldron;
    AudioSource m_audio;
    public GameObject FlameObject;
    public GameObject FlameLight;    
    public GameObject BubblesTwo;
    public AudioClip FlameWoosh;
    public bool Flamin = false;

    [Range(0, 1)] public float FlameVol;

    private void Start()
    {
        m_cauldron = GetComponentInParent<Cauldron>();
        m_audio = GetComponent<AudioSource>();
    }

    public void StartCooking()
    {
        m_cauldron.StartCooking();
        m_audio.PlayOneShot(FlameWoosh, FlameVol);
        m_audio.Play();
        FlameObject.SetActive(true);
        FlameLight.SetActive(true);        
        BubblesTwo.SetActive(true);
        Flamin = true;
    }

    public void StopCooking()
    {
        m_audio.Stop();
        FlameObject.SetActive(false);
        FlameLight.SetActive(false);        
        BubblesTwo.SetActive(false);
        Flamin = false;
    }
}
