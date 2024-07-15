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
    
    public CookState cookState;
    public enum Ingredient
    {
        LiveLemming,
        EyeOfNewt,
        MagicMushroom,
        SnakeTongue,
        MoonShard,
        BatWing,
        UnicornHorn,
        FrozenTear,
        WrappedCandy
    }

    [HideInInspector]
    public List<string> Ingredients;
    public List<Ingredient> IngredientSelect;
    [HideInInspector]
    public string Color;

    public void Activate()
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
        Ingredients.Clear();
        for(int i = 0; i < IngredientSelect.Count; i++)
        {
            switch(IngredientSelect[i])
            {
                default:
                case Ingredient.LiveLemming:
                    Ingredients.Add("Live Lemming");
                    break;
                case Ingredient.EyeOfNewt:
                    Ingredients.Add("Eye Of Newt");
                    break;
                case Ingredient.MagicMushroom:
                    Ingredients.Add("Magic Mushroom");
                    break;
                case Ingredient.SnakeTongue:
                    Ingredients.Add("Snake Tongue");
                    break;
                case Ingredient.MoonShard:
                    Ingredients.Add("Moon Shard");
                    break;
                case Ingredient.BatWing:
                    Ingredients.Add("Bat Wing");
                    break;
                case Ingredient.UnicornHorn:
                    Ingredients.Add("Unicorn Horn");
                    break;
                case Ingredient.FrozenTear:
                    Ingredients.Add("Frozen Tear");
                    break;
                case Ingredient.WrappedCandy:
                    Ingredients.Add("Wrapped Candy");
                    break;
            }
        }
    }
}
