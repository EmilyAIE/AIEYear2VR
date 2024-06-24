using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Cauldron : MonoBehaviour
{
    //Andrew's actual code
    float m_timer;
    [SerializeField]
    float m_cookStateDuration;
    AudioSource m_audioSource;
    public enum CookState
    {
        underCooked,
        light,
        medium,
        wellDone,
        overCooked,
    }

    [SerializeField]
    GameObject m_liquid;    
    Renderer m_liquidRenderer;

    public enum Color 
    { 
        Green,
        Purple,
        Amber
    }    

    [Header("Materials for Cooked State")]
    [SerializeField] Material m_default;
    [SerializeField] Material m_light;
    [SerializeField] Material m_medium;
    [SerializeField] Material m_wellDone;
           
    private CookState m_currentCookState;

    private Recipe m_activeRecipe;
    
    private List<string> m_currentIngredients;
    private List<string> m_targetIngredients;

    private bool m_isCooking;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_liquidRenderer = m_liquid.GetComponent<Renderer>();
    }

    private void Update()
    {
        while(m_isCooking)
        {
            m_timer += Time.deltaTime;
            if(m_timer >= m_cookStateDuration)
            {
                EnterCookState(m_currentCookState + 1);
            }
        }       
    }

    public void AddToMix(string ingredient)
    {
        m_currentIngredients.Add(ingredient);
    }

    private void EnterCookState(CookState cookstate)
    {
        m_currentCookState = cookstate;
        switch(m_currentCookState)
        {
            default:
                break;
            case CookState.underCooked:
                m_liquidRenderer.material = m_default;
                break;
            case CookState.light:
                m_liquidRenderer.material = m_light;
                break;
            case CookState.medium:
                m_liquidRenderer.material = m_medium;
                break;
            case CookState.wellDone:
                m_liquidRenderer.material = m_wellDone;
                break;
            case CookState.overCooked:
                m_liquidRenderer.material = m_default;
                m_isCooking = false;
                break;
        }
    }

    public void GetRecipe(Recipe recipe)
    {
        m_activeRecipe = recipe;
    }

    public bool CompareRecipe()
    {
        m_targetIngredients = m_activeRecipe.Ingredients;
        //if the cook state is incorrect, or if the number of ingredients is incorrect, recipe has failed
        if ((int)m_activeRecipe.CookState != (int)m_currentCookState)
        {
            return false;
        }
        if (m_currentIngredients.Count != m_targetIngredients.Count)
        {
            return false;
        }
        //Compare ingredients in cauldron to ingredients on recipe 
        for (int i = 0; i < m_currentIngredients.Count; i++)
        {
            for(int j = 0; j < m_targetIngredients.Count; j++)
            {
                if (m_currentIngredients[i] == m_targetIngredients[j])
                {
                    //if the ingredient is found in the target list, remove from target list and check next ingredient
                    m_targetIngredients.RemoveAt(j);
                    break;
                }
                //if the current ingredient cannot be found in the target ingredients list, the recipe has failed
                else if (i == m_currentIngredients.Count - 1)
                    return false;
            }
        }
        //If there are ingredients left in the target ingredients list, the recipe has failed
        if(m_targetIngredients.Count > 0)
        {
            return false;
        }
        //if cauldron has not failed any checks, return true
        return true;
    }

    public void StartCooking()
    {
        m_isCooking = true;
    }

    public void StopCooking()
    {
        m_timer = 0;
        m_targetIngredients.Clear();
        EnterCookState(CookState.underCooked);
        m_isCooking = false;
    }


}