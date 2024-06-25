using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronCollider : MonoBehaviour
{    
    private Cauldron m_cauldron;
    // Start is called before the first frame update

    private void Start()
    {
        m_cauldron = GetComponentInParent<Cauldron>();   
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Vial"))
        {
            Vial vial = collider.GetComponentInParent<Vial>();
            if(vial.CheckOrientation())
            {
                vial.Colour = m_cauldron.Colour.ToString();
                vial.CorrectPotion = m_cauldron.CompareRecipe();
                vial.SetLiquid(m_cauldron.GetCookState());
                if(vial.CorrectPotion)
                {
                    Debug.Log("Potion Is Correct");
                }
                else
                {
                    Debug.Log("Potion Is Incorrect");
                }
                m_cauldron.StopCooking();
            }            
        }
        if(collider.CompareTag("Ingredient"))
        {            
            Ingredient ingredient = collider.GetComponentInParent<Ingredient>();
            m_cauldron.AddToMix(ingredient.Name);
            ingredient.DestroyIngredient();
        }
    }
}
