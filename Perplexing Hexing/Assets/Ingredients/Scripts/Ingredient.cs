using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    // Dan's Dodgy Code

    public string Name;
    public cookState CookState;
    public string Color;
    public List<Ingredient> Ingredients;

    public enum cookState
    {
        underCooked,
        light,
        medium,
        wellDone,
        overCooked,
    }


}
