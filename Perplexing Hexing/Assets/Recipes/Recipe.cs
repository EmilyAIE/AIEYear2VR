using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", order = 1)]
public class Recipe : ScriptableObject
{
    public string Title;
    public enum cookState
    {
        underCooked,
        light,
        medium,
        wellDone,
        overCooked
    }
    public cookState CookState;
    public string Color;
    public List<string> Ingredients; 


}
