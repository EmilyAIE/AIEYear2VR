using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    // Dan's Dodgy Code

    public IngredientType type;

    public enum IngredientType
    {
        batWing,
        eyeOfNewt,
        frogTongue
    }

    public void FallIntoCauldron()
    {
        Destroy(gameObject);
    }
}
