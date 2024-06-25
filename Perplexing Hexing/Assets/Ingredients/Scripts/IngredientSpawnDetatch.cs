using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawnDetatch : MonoBehaviour
{
    RegenIngredient m_spawner;

    private void Start()
    {
        m_spawner = transform.parent.GetComponentInParent<RegenIngredient>();
    }

    /// <summary>
    /// Call this when an object is selected to make sure it detatches from the spawn game object
    /// </summary>
    public void DetatchFromParent()
    {
        m_spawner.MoveToActive(this.transform);
    }

    public void Deactivate()
    {
        m_spawner.SetInactive(gameObject);
    }
}
