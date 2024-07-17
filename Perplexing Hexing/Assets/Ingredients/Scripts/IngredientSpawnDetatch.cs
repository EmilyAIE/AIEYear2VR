using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawnDetatch : MonoBehaviour
{
    RegenIngredient m_spawner;    
    Vector3 m_startPosition;
    bool attached;

    private void OnEnable()
    {
        attached = true;
        m_spawner = transform.parent.GetComponentInParent<RegenIngredient>();        
        m_startPosition = transform.position;
    }

    private void Update()
    {
        if(attached)
        {
            Vector3 difVector = transform.position - m_startPosition;
            float difFloat = difVector.magnitude;
            if (difFloat > 0.3f)
            {
                DetatchFromParent();
            }
        }
    }

    /// <summary>
    /// Call this when an object is selected to make sure it detatches from the spawn game object
    /// </summary>
    public void DetatchFromParent()
    {
        attached = false;
        m_spawner.MoveToActive(this.transform);
    }

    public void Deactivate()
    {
        m_spawner.SetInactive(gameObject);
    }
}
