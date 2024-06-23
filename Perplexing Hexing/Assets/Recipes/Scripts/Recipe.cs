using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", order = 1)]
public class Recipe : ScriptableObject
{
    public string Title;
    public enum color
    {
        Green,
        Purple,
        Amber
    }
    public color Colour;
    public enum cookState
    {
        underCooked,
        light,
        medium,
        wellDone,
        overCooked
    }
    public cookState CookState;    
    public List<string> Ingredients;
    [HideInInspector]
    public string Color;

    private void Awake()
    {
        switch(Colour)
        {
            default:
                break;
            case color.Green:
                Color = "Green";
                break;
            case color.Purple:
                Color = "Purple";
                break;
            case color.Amber:
                Color = "Amber";
                break;

        }
    }


}
