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
            Vial vial = collider.GetComponent<Vial>();
            if(vial.CheckOrientation())
            {
                vial.Colour = m_cauldron.Colour.ToString();
                vial.CorrectPotion = m_cauldron.CompareRecipe();
            }
            Debug.Log("I AM A VIAL AND IM FULL OF " + vial.Colour + " JUICE");
        }
        if(collider.CompareTag("Ingredient"))
        {
            Ingredient ingredient = collider.GetComponent<Ingredient>();
            m_cauldron.AddToMix(ingredient.Name);
            Destroy(ingredient.gameObject);
        }
    }
}
