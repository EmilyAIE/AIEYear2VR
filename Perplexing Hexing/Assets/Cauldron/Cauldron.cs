using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    //Andrew's actual code
    float m_timer;
    [SerializeField]
    float m_cookStateDuration;    
    AudioSource m_audioSource;
    enum CookState
    {
        underCooked,
        light,
        medium,
        wellDone,
        overCooked,
    }
    
    Material m_liquidMaterial;
    GameObject m_liquid;
    string m_liquidColorType;

    [Header("Materials for Cooked State")]
    [SerializeField] Material m_default;
    [SerializeField] Material m_light;
    [SerializeField] Material m_medium;
    [SerializeField] Material m_wellDone;


    CookState m_cookState;


    //Dan's Dodgy Code
    private List<string> m_currentIngredients;

    //Em's dubiuos code
    public float Potion = 0;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>();
        if (ingredient != null)
        {
            //m_currentIngredients.Add();
            //ingredient.FallIntoCauldron();
           
        }
        
    }
}
