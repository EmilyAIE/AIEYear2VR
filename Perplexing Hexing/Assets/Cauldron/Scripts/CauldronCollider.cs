using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronCollider : MonoBehaviour
{    
    private Cauldron m_cauldron;

    [SerializeField]
    GameObject m_batWing, m_eyeOfNewt, m_frozenTear, m_livingLemming, m_magicMushroom, m_moonShard, m_snakesTongue, m_unicornHorn, m_wrappedCandy;
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
            if(vial.CheckOrientation() && vial.CanFill)
            {
                vial.CanFill = false;
                vial.Colour = m_cauldron.Colour.ToString();
                vial.CorrectPotion = m_cauldron.CompareRecipe(vial.VialType);
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
            return;
        }
        if(collider.CompareTag("Ingredient"))
        {            
            Ingredient ingredient = collider.GetComponentInParent<Ingredient>();
            m_cauldron.AddToMix(ingredient.Name);
            InstantiateFloatingIngredient(ingredient.Name, ingredient.transform);
            ingredient.DestroyIngredient();
            
            return;
        }
        if(collider.CompareTag("Sponge"))
        {
            m_cauldron.EnterCookState(CookState.overCooked);
            Ingredient ingredient = collider.GetComponentInParent<Ingredient>();            
            ingredient.DestroyIngredient();
            
        }
    }

    public void InstantiateFloatingIngredient(string ingredient, Transform transform)
    {
        switch(ingredient)
        {
            case "Bat Wing":
                Instantiate(m_batWing, transform.position, transform.rotation, m_cauldron.FloatingIngredientsParent.transform);
                break;
            case "Eye Of Newt":
                Instantiate(m_eyeOfNewt, transform.position, transform.rotation, m_cauldron.FloatingIngredientsParent.transform);
                break;
            case "Frozen Tear":
                Instantiate(m_frozenTear, transform.position, transform.rotation, m_cauldron.FloatingIngredientsParent.transform);
                break;
            case "Living Lemming":
                Instantiate(m_livingLemming, transform.position, transform.rotation, m_cauldron.FloatingIngredientsParent.transform);
                break;
            case "Magic Mushroom":
                Instantiate(m_magicMushroom, transform.position, transform.rotation, m_cauldron.FloatingIngredientsParent.transform);
                break;
            case "Moon Shard":
                Instantiate(m_moonShard, transform.position, transform.rotation, m_cauldron.FloatingIngredientsParent.transform);
                break;
            case "Snakes Tongue":
                Instantiate(m_snakesTongue, transform.position, transform.rotation, m_cauldron.FloatingIngredientsParent.transform);
                break;
            case "Unicorn Horn":
                Instantiate(m_unicornHorn, transform.position, transform.rotation, m_cauldron.FloatingIngredientsParent.transform);
                break;
            case "Wrapped Candy":
                Instantiate(m_wrappedCandy, transform.position, transform.rotation, m_cauldron.FloatingIngredientsParent.transform);
                break;
        }
    }
}
