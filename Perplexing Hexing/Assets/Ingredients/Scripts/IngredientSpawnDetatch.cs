using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawnDetatch : MonoBehaviour
{
    /// <summary>
    /// Call this when an object is selected to make sure it detatches from the spawn game object
    /// </summary>
    public void DetatchFromParent()
    {
        transform.parent = null;
    }

}
