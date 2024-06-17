using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    //Dan's Dodgy Code
    public List<Ingredient.IngredientType> currentIgredients;

    //Em's dubiuos code
    public float Potion = 0;

    private void OnTriggerEnter(Collider other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>();
        if (ingredient != null)
        {
            currentIgredients.Add(ingredient.type);
            ingredient.FallIntoCauldron();
        }
        
    }
}
